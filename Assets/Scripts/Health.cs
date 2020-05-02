using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    //escudo y mas...

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setHealth((int)maxHealth);
    }

    public void takeDamage(float damage) {
        currentHealth -= damage;
        healthBar.setHealth((int)currentHealth);
		
        if (currentHealth <= 0)
            Debug.Log("Estas muerto colega");



    }
}
