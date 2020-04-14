using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    public float speed = 10f;
    public float boostSpeed = 20f;
    

    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public void Execute(Vector3 moveDirection, Vector3 objective, bool dodge)
    {
        rigidbody.velocity = moveDirection * speed;
        transform.LookAt(objective);
    }


}
