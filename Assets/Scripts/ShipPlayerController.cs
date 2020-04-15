using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayerController : MonoBehaviour
{
    ShipMoveComponent moveComponent;
    ScreenAimComponent aimComponent;
    AttackComponent attackComponent;

    void Start()
    {
        moveComponent = this.GetComponent<ShipMoveComponent>();
        aimComponent = this.GetComponent<ScreenAimComponent>();
        attackComponent = this.GetComponent<AttackComponent>();
    }


    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 objective = Vector3.zero;

        if (aimComponent != null)
        {
            objective = aimComponent.GetAimPosition();
        }

        if (moveComponent != null)
        {
            moveComponent.SideMove(moveDirection);
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
    }
}
