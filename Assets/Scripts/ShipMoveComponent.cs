using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveComponent : MonoBehaviour
{

    public float speed = 5f;
    public float lateralSpeed = 5f;
    public float rotationAngle = 10f;
    public float boostMultiplier = 10.0f;
    public Vector2 positionLimits = new Vector2(10, 10);

    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 moveDirection)
    {
        ApplyPositionLimits(ref moveDirection);
        rigidbody.velocity = new Vector3(moveDirection.x * lateralSpeed, moveDirection.y * lateralSpeed, moveDirection.z * speed);

        //rotate test
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, - moveDirection.x * rotationAngle);
    }


    public void Accelerate(Vector3 moveDirection)
    {
    	ApplyPositionLimits(ref moveDirection);

    	rigidbody.velocity = new Vector3(moveDirection.x * lateralSpeed, moveDirection.y * lateralSpeed, moveDirection.z * speed * boostMultiplier);
    }


    public void LookAt(Vector3 position)
    {
        var rotation = Quaternion.LookRotation(position - transform.position).eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, transform.eulerAngles.z);
        //transform.LookAt(position);
    }


    public void Dodge()
    {
        //Coroutine during X seconds ??
    }


    // check positions limits and correct moveDirection to slow down ship when outside them
    private void ApplyPositionLimits(ref Vector3 moveDirection)
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;

        float k = 0.8f;

        if (x >= k*positionLimits.x && moveDirection.x > 0)
        {
            moveDirection.x *= 1 - (x - k*positionLimits.x) / (positionLimits.x);
        }
        else if (x <= -k*positionLimits.x && moveDirection.x < 0)
        {
            moveDirection.x *= 1 - (x - -k*positionLimits.x) / (-positionLimits.x);
        }

        if (y >= k*positionLimits.y && moveDirection.y > 0)
        {
            moveDirection.y *= 1 - (y - k*positionLimits.y) / (positionLimits.y);
        }
        else if (y <= -k*positionLimits.y && moveDirection.y < 0)
        {
            moveDirection.y *= 1 - (y - -k*positionLimits.y) / (-positionLimits.y);
        }
    }


}
