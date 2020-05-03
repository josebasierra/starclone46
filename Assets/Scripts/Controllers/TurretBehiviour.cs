using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehiviour : MonoBehaviour
{
    AttackComponent attackComponent;
    Vector3 playerPosition;
    GameObject cylinder;
    
    // Start is called before the first frame update
    void Start()
    {
    	attackComponent = this.GetComponent<AttackComponent>();
    	cylinder = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		
		LookAt(playerPosition);

		if (attackComponent != null)
        {
            attackComponent.BasicAttack();
        }
    }

    public void LookAt(Vector3 target)
    {
    	Vector3 targetPosition = new Vector3(target.x,transform.position.y,target.z); //rotate in Y-axis
    	transform.LookAt(targetPosition);
    	cylinder.transform.LookAt(targetPosition);
    }
}
