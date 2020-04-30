using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    PlayerMovement moveComponent;
    Crosshair aimComponent;
    AttackComponent attackComponent;
    Health health;


    void Start()
    {
        moveComponent = this.GetComponent<PlayerMovement>();
        aimComponent = this.GetComponent<Crosshair>();
        attackComponent = this.GetComponent<AttackComponent>();
        health = this.GetComponent<Health>();
    }


    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1);
        Vector3 objective = Vector3.zero;


        if (aimComponent != null)
        {
            objective = aimComponent.GetAimPosition();
            moveDirection = (objective - transform.position).normalized;
        }

        if (moveComponent != null)
        {
            moveComponent.Move(moveDirection);
            moveComponent.LookAt(transform.position + moveDirection * 10);

            if (Input.GetButton("Boost"))
            {
                moveComponent.Accelerate();
            }
        }


        if (attackComponent != null)
        {
            if (Input.GetButton("Fire1"))
            {
                attackComponent.BasicAttack();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ship Collision");

    }

    private void OnTriggerEnter(Collider other)
    {
        health.takeDamage(10);
    }
}
