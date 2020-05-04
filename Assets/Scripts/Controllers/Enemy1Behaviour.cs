using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{
	AttackComponent attackComponent;
	BasicMovement moveComponent;
	
	public Transform target;

	Vector3 playerPosition;
    Transform transformPlayer;


    void Start()
    {
        attackComponent = this.GetComponent<AttackComponent>();
        moveComponent = this.GetComponent<BasicMovement>();
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //TODO: findPlayer once in start (save its transform)
    void Update()
    {  
    	if (transformPlayer != null) playerPosition = transformPlayer.position;
    	
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
