using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
	AttackComponent attackComponent;
	ShipMoveComponent moveComponent;

	Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        attackComponent = this.GetComponent<AttackComponent>();
        moveComponent = this.GetComponent<ShipMoveComponent>();
    }

    // Update is called once per frame
    void Update()
    {  
    	playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    	
    	if (moveComponent != null)
        {
            moveComponent.LookAt(playerPosition);
        }

        if (attackComponent != null)
        {
            attackComponent.enemyAttack(playerPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemigo disparado");
        //explota nave al cabo de ciertos disparos...
    }
}
