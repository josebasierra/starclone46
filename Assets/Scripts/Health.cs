using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float maxHealth = 20.0f;
    public float healHealth = 10.0f;

    public event Action OnDeath;

    float currentHealth;
    bool bulletImmunity;

    bool fullImmunity;


    void Start()
    {
        currentHealth = maxHealth;
        bulletImmunity = false;
        fullImmunity = false;
    }


    public void TakeDamage(float damage)
    {

        if (fullImmunity) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();   //invocation of OnDeath event
            Destroy(this.gameObject);
        }
    }

    public void Heal()
    {
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


    //TODO: on asteroid clash sound/effect
    //TODO: die if clash with Static tag
    private void OnCollisionEnter(Collision collision)
    {
        fullImmunity = true;
        if (fullImmunity && collision.transform.tag == "Static") StartCoroutine(ColliderDesactivation());
    }


    private IEnumerator ColliderDesactivation()
    {
        float desactivationTime = 1f;
        float t = 0;

        transform.Find("Colliders").gameObject.SetActive(false);
        while (t < desactivationTime)
        {
            yield return null;
            t += Time.deltaTime;
        }
        transform.Find("Colliders").gameObject.SetActive(true);
    }
}
