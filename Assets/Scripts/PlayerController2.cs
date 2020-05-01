using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    PlayerMovement moveComponent;
    Crosshair aimComponent;
    AttackComponent attackComponent;

    float doubleTapTime;
    float timeSinceLastTap_W;
    float timeSinceLastTap_S;
    float timeSinceLastTap_A;
    float timeSinceLastTap_D;

    void Start()
    {
        moveComponent = this.GetComponent<PlayerMovement>();
        aimComponent = this.GetComponent<Crosshair>();
        attackComponent = this.GetComponent<AttackComponent>();

        doubleTapTime = 1f;
        timeSinceLastTap_W = doubleTapTime;
        timeSinceLastTap_S = doubleTapTime;
        timeSinceLastTap_A = doubleTapTime;
        timeSinceLastTap_D = doubleTapTime;

    }


    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1);
        Vector3 objective = Vector3.zero;


        if (aimComponent != null)
        {
            objective = aimComponent.GetAimPosition();
            moveDirection = (objective - transform.position).normalized;
            moveDirection.x *= 2f;
            moveDirection.y *= 2f;

        }

        if (moveComponent != null)
        {
            moveComponent.Move(moveDirection);
            moveComponent.LookAt(objective);

            if (Input.GetButton("Boost"))
            {
                moveComponent.Boost();
            }
            if (Input.GetKeyDown("w"))
            {
                if (timeSinceLastTap_W < doubleTapTime)
                    moveComponent.Roll(Vector2.up);
                timeSinceLastTap_W = 0;
            }
            if (Input.GetKeyDown("s"))
            {
                if (timeSinceLastTap_S < doubleTapTime)
                    moveComponent.Roll(Vector2.down);
                timeSinceLastTap_S = 0;
            }
            if (Input.GetKeyDown("a"))
            {
                if (timeSinceLastTap_A < doubleTapTime)
                    moveComponent.Roll(Vector2.left);
                timeSinceLastTap_A = 0;
            }
            if (Input.GetKeyDown("d"))
            {
                if (timeSinceLastTap_D < doubleTapTime)
                    moveComponent.Roll(Vector2.right);
                timeSinceLastTap_D = 0;
            }

            timeSinceLastTap_W += Time.deltaTime;
            timeSinceLastTap_S += Time.deltaTime;
            timeSinceLastTap_A  += Time.deltaTime;
            timeSinceLastTap_D += Time.deltaTime;
        }

        if (attackComponent != null)
        {
            if (Input.GetButton("Fire1"))
            {
                attackComponent.BasicAttack();
            }
            if (Input.GetButton("Fire2"))
            {
                attackComponent.SpecialAttack();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ship Collision");

    }


}
