using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{
	AttackComponent attackComponent;
	BasicMovement moveComponent;
	
	public Transform target;

	Vector3 playerPosition;


    void Start()
    {
        attackComponent = this.GetComponent<AttackComponent>();
        moveComponent = this.GetComponent<BasicMovement>();
    }

    //TODO: findPlayer once in start (save its transform)
    void Update()
    {  
    	playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    	
    	if (moveComponent != null)
        {
            moveComponent.LookAt(playerPosition);
            if (target != null) moveComponent.MoveTo(target.position); 
        }

        if (attackComponent != null)
        {
            attackComponent.BasicAttack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Enemigo disparado");
        //explota nave al cabo de ciertos disparos...
    }
}
