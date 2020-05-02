using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //escudo y mas...

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
		
        if (currentHealth <= 0)
            Debug.Log("Estas muerto colega");
    }

    public int getHealth() {
        return currentHealth;
    }
}
