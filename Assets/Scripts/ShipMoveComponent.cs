using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveComponent : MonoBehaviour
{

    public float speed = 10f;
    public float boostSpeed = 20f;
    

    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }



    public void SideMove(Vector2 moveDirection)
    {
        rigidbody.velocity = moveDirection * speed;
    }


    public void LookAt(Vector3 position)
    {
        transform.LookAt(position);
    }


    public void Dodge()
    {
        //Coroutine during X seconds ??
    }



}
