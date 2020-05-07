using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement moveComponent;
    Crosshair aimComponent;
    AttackComponent attackComponent;
    Health health;
    Energy energy;

    float doubleTapTime;
    float timeSinceLastTap_W;
    float timeSinceLastTap_S;
    float timeSinceLastTap_A;
    float timeSinceLastTap_D;

    PauseManager pauseManager;

    void Start()
    {
        moveComponent = this.GetComponent<PlayerMovement>();
        aimComponent = this.GetComponent<Crosshair>();
        attackComponent = this.GetComponent<AttackComponent>();
        health = GetComponent<Health>();
        energy = GetComponent<Energy>();

        doubleTapTime = 1f;
        timeSinceLastTap_W = doubleTapTime;
        timeSinceLastTap_S = doubleTapTime;
        timeSinceLastTap_A = doubleTapTime;
        timeSinceLastTap_D = doubleTapTime;

        pauseManager = GameObject.Find("PauseManager").GetComponent<PauseManager>();
    }


    void Update()
    {
        if (pauseManager != null && pauseManager.IsPaused()) return;

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1);
        Vector3 objective = Vector3.zero;


        if (aimComponent != null && aimComponent.enabled)
        {
            objective = aimComponent.GetAimPosition();
            moveDirection = (objective - transform.position).normalized;
            moveDirection.x *= 2f;
            moveDirection.y *= 2f;
        }

        if (moveComponent != null && moveComponent.enabled)
        {
            moveComponent.Move(moveDirection);
            moveComponent.LookAt(objective);

            if (Input.GetButton("Boost"))
            {
                moveComponent.Boost();
            }

            if (Input.GetButton("SlowDown"))
            {
                moveComponent.SlowDown();
            }
            else if (Input.GetButtonUp("SlowDown"))
            {
                moveComponent.StopSlowingDown();
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

                moveComponent.StartTilting(-1);
                timeSinceLastTap_A = 0;
            }
            else if (Input.GetKeyUp("a"))
            {
                moveComponent.StopTilting();
            }

            if (Input.GetKeyDown("d"))
            {
                if (timeSinceLastTap_D < doubleTapTime)
                    moveComponent.Roll(Vector2.right);
                
                moveComponent.StartTilting(1);
                timeSinceLastTap_D = 0;
            }
            else if (Input.GetKeyUp("d"))
            {
                moveComponent.StopTilting();
            }

            timeSinceLastTap_W += Time.deltaTime;
            timeSinceLastTap_S += Time.deltaTime;
            timeSinceLastTap_A += Time.deltaTime;
            timeSinceLastTap_D += Time.deltaTime;
        }

        if (attackComponent != null && attackComponent.enabled)
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

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "HealthSupply") {
            health.Heal();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "EnergySupply") {
            energy.Recharge();
            Destroy(other.gameObject);
        }
    }
}
