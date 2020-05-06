using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationMemberController : MonoBehaviour
{
    Formation formation;
    Transform aimTarget;

    AttackComponent attackComponent;
    BasicMovement moveComponent;



    void Start()
    {
        formation = GameObject.Find("Formation").GetComponent<Formation>();
        aimTarget = GameObject.Find("PlayerShip").transform;

        attackComponent = GetComponent<AttackComponent>();
        moveComponent = GetComponent<BasicMovement>();

        GetComponent<Health>().OnDeath += OnDeath;

    }

    //fixed update to avoid laggy movement (look for alternatives)
    void FixedUpdate()
    {
        formation.AddMember(transform);

        moveComponent.LookAt(aimTarget.position);

        var moveTarget = formation.GetTargetPosition(transform);
        if (moveTarget != null)  moveComponent.MoveTo(moveTarget.position);

        if (attackComponent != null) attackComponent.BasicAttack();
    }

    void OnDeath()
    {
        formation.DeleteMember(transform);
    }

    void OnDisable()
    {
        GetComponent<Health>().OnDeath -= OnDeath;
    }
}
