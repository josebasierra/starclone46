using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    AttackComponent attackComponent;
    Vector3 playerPosition;
    Transform cannon;

    Transform transformPlayer;
    

    void Start()
    {
    	attackComponent = this.GetComponent<AttackComponent>();
    	cannon = transform.GetChild(0);
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    
    //TODO: call findPlayer only once in start
    void Update()
    {
        if (transformPlayer != null) 
        {
            playerPosition = transformPlayer.position;
            LookAt(playerPosition);
        } 
		
		if (attackComponent != null)
        {
            attackComponent.BasicAttack();
        }
    }

    public void LookAt(Vector3 target)
    {
    	Vector3 targetPosition = new Vector3(target.x,transform.position.y,target.z); //rotate in Y-axis
    	transform.LookAt(targetPosition);
    	cannon.LookAt(target);
    }
}
