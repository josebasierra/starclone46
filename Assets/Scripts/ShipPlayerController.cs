using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayerController : MonoBehaviour
{
    ShipMoveComponent moveComponent;
    ScreenAimComponent aimComponent;
    AttackComponent attackComponent;
    PlayerStats stats;

    void Start()
    {
        moveComponent = this.GetComponent<ShipMoveComponent>();
        aimComponent = this.GetComponent<ScreenAimComponent>();
        attackComponent = this.GetComponent<AttackComponent>();
        stats = this.GetComponent<PlayerStats>();
    }


    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1);
        Vector3 objective = Vector3.zero;

        if (aimComponent != null)
        {
            objective = aimComponent.GetAimPosition();
        }

        if (moveComponent != null)
        {
            moveComponent.Move(moveDirection);
            moveComponent.LookAt(objective);
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
        stats.takeDamage(10); 
    }
}
