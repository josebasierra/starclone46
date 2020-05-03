using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
	AttackComponent attackComponent;
	BasicMovement moveComponent;
	
	public GameObject targetObject;

	Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        attackComponent = this.GetComponent<AttackComponent>();
        moveComponent = this.GetComponent<BasicMovement>();
    }

    // Update is called once per frame
    void Update()
    {  
    	playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    	
    	if (moveComponent != null)
        {
            moveComponent.LookAt(playerPosition);
            moveComponent.MoveTo(targetObject); 
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
