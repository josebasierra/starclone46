using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Settings")]
    public float forwardSpeed = 5f;
    public float lateralSpeed = 5f;
    public float rotationAngle = 10f;
    public float rotationSpeed = 140f;
    public Vector2 positionLimits = new Vector2(10, 10);

    [Header("Boost Settings")]
    public float boostSpeedMultiplier = 2f;
    public float boostFuelPerSecond = 10.5f;

    [Header("SlowDown Settings")]
    public float slowForwardMultiplier = 0.5f;
    public float slowLateralMultiplier = 0.2f;

    [Header("Roll Settings")]
    public float rollSpeedMultiplier = 2;
    public float rollDuration = 1;
    public float turns = 2;        //vueltas que da la nave sobre si misma en un roll
    public float rollFuelCost = 40f;

    [Header("Fuel Settings")]
    public float fuelPerSecond = 2.5f;
    public float MaxFuel = 10.0f;

    bool isRolling;
    bool isTilting;
    bool isSlowingDown;
    bool canBoost;
    float currentFuel;

    Rigidbody rigidbody;
    Health health;


    void Start()
    {
        isRolling = false;
        isTilting = false;
        isSlowingDown = false;
        canBoost = false; 
        currentFuel = MaxFuel;

        rigidbody = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
    }


    void Update()
    {
        ApplyPositionLimits();
        if (currentFuel <= MaxFuel) currentFuel += fuelPerSecond * Time.deltaTime; //se va aumentando el fuel
    }


    public void Move(Vector3 moveDirection)
    {
        if (isRolling) return;

        rigidbody.velocity = new Vector3(moveDirection.x * lateralSpeed, moveDirection.y * lateralSpeed, forwardSpeed);

        if (isTilting) return;

        // spaceship balance effect when moving to sides
        float slowDownFactor = isSlowingDown ? slowLateralMultiplier : 1;
        var targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y,slowDownFactor * -moveDirection.x*rotationAngle);
        transform.rotation =  Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
    }


    public void Boost()
    {
        if (isSlowingDown) return;

        if (currentFuel > 0.0f && canBoost)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, forwardSpeed * boostSpeedMultiplier);
            currentFuel -= boostFuelPerSecond * Time.deltaTime;
        }
        else if (currentFuel >= 0.2*MaxFuel && !canBoost)
            canBoost = true;
        else if (currentFuel <= 0) 
            canBoost = false;
    }


    public void SlowDown()
    {
        isSlowingDown = true;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x * slowLateralMultiplier, rigidbody.velocity.y * slowLateralMultiplier,  forwardSpeed * slowForwardMultiplier);
    }

    public void StopSlowingDown()
    {
        isSlowingDown = false;
    }

    public void Roll(Vector2 rollDirection)
    {
        if (!isRolling && currentFuel >= rollFuelCost)
        {
            currentFuel -= rollFuelCost;
            StartCoroutine(Rolling(rollDirection));
        }
            
    }


    public void StartTilting(int direction)
    {
        if (!isTilting)
            StartCoroutine(Tilting(direction));
    }


    public void StopTilting()
    {
        isTilting = false;
    }


    public void LookAt(Vector3 position)
    {
        var rotation = Quaternion.LookRotation(position - transform.position).eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, transform.eulerAngles.z);
    }


    public float GetCurrentFuel() => currentFuel;
    public float GetMaxFuel() => MaxFuel;


    private IEnumerator Rolling(Vector2 rollDirection)
    {
        isRolling = true;
        if (health != null) health.SetBulletImmunity(true);
        rigidbody.velocity = new Vector3(rollDirection.x * lateralSpeed * rollSpeedMultiplier, rollDirection.y * lateralSpeed * rollSpeedMultiplier, rigidbody.velocity.z);

        float timeRolling = 0;
        float turnDirection = rollDirection.x >= 0 ? -1 : 1;

        while (timeRolling < rollDuration)
        {
            float rotationIncrement =  turnDirection * turns * 360 / rollDuration * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotationIncrement);

            timeRolling += Time.deltaTime;
            yield return null;
        }

        isRolling = false;
        if (health != null) health.SetBulletImmunity(false);
    }


    private IEnumerator Tilting(int direction)
    {
        isTilting = true;
        while (isTilting)
        {
            if (!isRolling)
            {
                var targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -direction * 90);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * 1.5f * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void ApplyPositionLimits()
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;

        float vx = rigidbody.velocity.x;
        float vy = rigidbody.velocity.y;

        float k = 0.8f;

        if (x >= k * positionLimits.x && vx > 0)
        {
            vx *= 1 - (x - k * positionLimits.x) / (positionLimits.x);
        }
        else if (x <= -k * positionLimits.x && vx < 0)
        {
            vx *= 1 - (x - -k * positionLimits.x) / (-positionLimits.x);
        }

        if (y >= k * positionLimits.y && vy > 0)
        {
            vy *= 1 - (y - k * positionLimits.y) / (positionLimits.y);
        }
        else if (y <= -k * positionLimits.y && vy < 0)
        {
            vy *= 1 - (y - -k * positionLimits.y) / (-positionLimits.y);
        }

        rigidbody.velocity = new Vector3(vx, vy, rigidbody.velocity.z);
    }


}
