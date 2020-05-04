using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyBehaviour : MonoBehaviour
{	
	Health health;
	Energy energy;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        energy = GetComponent<Energy>();
    }

    private void OnCollisionEnter(Collision other) {
    	if (other.gameObject.tag == "HealthSupply") {
    		health.heal();
    	}
    	
    	if (other.gameObject.tag == "EnergySupply")	{
    		energy.recharge();
    	}

    	Destroy(other.gameObject);
    }
}
