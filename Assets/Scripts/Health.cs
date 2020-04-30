using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //escudo y mas...

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
		
        if (currentHealth <= 0)
            Debug.Log("Estas muerto colega");



    }
}
