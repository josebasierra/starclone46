﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Settings")]
    public float forwardSpeed = 5f;
    public float lateralSpeed = 5f;
    public float rotationAngle = 10f;
    public Vector2 positionLimits = new Vector2(10, 10);

    [Header("Boost Settings")]
    public float boostMultiplier = 10.0f;
    public float MaxboostFuel = 10.0f;
    public BoostFuelBar boostFuelBar;

    [Header("Roll Settings")]
    public float rollMultiplier = 2;
    public float rollDuration = 1;
    public int turns = 2;        //vueltas que da la nave sobre si misma en un roll

    bool rolling;
    float boostFuel;
    Rigidbody rigidbody;

    void Start()
    {
        rolling = false;
        boostFuel = MaxboostFuel;
        boostFuelBar.setFuel(MaxboostFuel);
        rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ApplyPositionLimits();
        if (boostFuel <= MaxboostFuel) boostFuel += 1.5f; //se va aumentando el fuel
        boostFuelBar.setFuel(boostFuel);
    }


    public void Move(Vector3 moveDirection)
    {
        if (rolling) return;

        rigidbody.velocity = new Vector3(moveDirection.x * lateralSpeed, moveDirection.y * lateralSpeed, 1 * forwardSpeed);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, - moveDirection.x * rotationAngle);
    }


    public void Boost()
    {
        if (boostFuel > 0.0f) {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 1f * forwardSpeed * boostMultiplier);
            boostFuel -= 1.75f;
            boostFuelBar.setFuel(boostFuel);
            Debug.Log(boostFuel);
        } 
        else {
            Debug.Log("No tienes suficiente fuel");
        }
    }


    public void Roll(Vector2 rollDirection)
    {
        if (!rolling)
            StartCoroutine(Rolling(rollDirection));
    }


    public void LookAt(Vector3 position)
    {
        var rotation = Quaternion.LookRotation(position - transform.position).eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, transform.eulerAngles.z);
        //transform.LookAt(position);
    }



    private IEnumerator Rolling(Vector2 rollDirection)
    {
        rolling = true;

        float timeRolling = 0;
        float turnDirection = rollDirection.x >= 0 ? -1 : 1;

        rigidbody.velocity = new Vector3(rollDirection.x * lateralSpeed * rollMultiplier, rollDirection.y * lateralSpeed * rollMultiplier, rigidbody.velocity.z);

        while(timeRolling < rollDuration)
        {
            float rotationIncrement =  turnDirection * turns * 360 / rollDuration * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotationIncrement);

            timeRolling += Time.deltaTime;
            yield return null;
        }
        rolling = false;
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
