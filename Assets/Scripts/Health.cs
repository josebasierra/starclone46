﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 20.0f;
    public float healHealth = 10.0f;
    //escudo y mas...

    float currentHealth;
    bool bulletImmunity;
    bool isDead;


    void Start()
    {
        currentHealth = maxHealth;
        bulletImmunity = false;
        isDead = false;
    }


    public void TakeDamage(float damage) {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
            //temporal:
            Destroy(this.gameObject);
        }      
    }

    public void heal() {
        currentHealth += healHealth;
    }

    public float GetCurrentHealth() => currentHealth;

    public float GetMaxHealth() => maxHealth;

    public bool GetBulletImmunity(bool value) => bulletImmunity;

    public void SetBulletImmunity(bool value) => bulletImmunity = value;

    // check for bullet impacts (bullet = object with damage component)
    private void OnTriggerEnter(Collider other)
    {
        var damageComponent = other.gameObject.GetComponent<DamageComponent>();
        if (damageComponent != null && other.tag != this.tag && !bulletImmunity)
        {
            TakeDamage(damageComponent.GetDamage());
        }
    }
}
