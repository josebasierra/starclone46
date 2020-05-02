using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    //escudo y mas...


    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Debug.Log("Estas muerto colega");
    }


    public float GetHealth() {
        return currentHealth;
    }
}
