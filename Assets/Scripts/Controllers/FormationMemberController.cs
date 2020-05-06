using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationMemberController : MonoBehaviour
{
    public float detectionRange = 100;

    Formation formation;
    Transform player;

    AttackComponent attackComponent;
    BasicMovement moveComponent;


    void Start()
    {
        formation = GameObject.Find("Formation").GetComponent<Formation>();
        player = GameObject.Find("PlayerShip").transform;

        attackComponent = GetComponent<AttackComponent>();
        moveComponent = GetComponent<BasicMovement>();

        GetComponent<Health>().OnDeath += OnDeath;
        formation.OnFormationAttack += OnFormationAttack;
    }

    //FixedUpdate to avoid laggy movement (look for alternatives)
    void FixedUpdate()
    {
        if (player == null) return;
        if (Mathf.Abs(player.position.z - transform.position.z) >= detectionRange) return;

        formation.AddMember(transform);

        if (moveComponent != null)
        {
            var moveTarget = formation.GetTargetPosition(transform);
            if (moveTarget != null) moveComponent.MoveTo(moveTarget.position);
            moveComponent.LookAt(player.position);
        }
    }


    void OnFormationAttack()
    {
        attackComponent?.BasicAttack();
    }


    void OnDeath()
    {
        formation.DeleteMember(transform);
    }


    void OnDisable()
    {
        GetComponent<Health>().OnDeath -= OnDeath;
        formation.OnFormationAttack -= OnFormationAttack;
    }
}
