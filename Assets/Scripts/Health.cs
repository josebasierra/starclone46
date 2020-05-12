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
    bool godMode;

    public GameObject explosion;

    void Start()
    {
        currentHealth = maxHealth;
        bulletImmunity = false;
        godMode = false;
    }

    public void TakeDamage(float damage)
    {

        if (godMode) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            
            //crear explosion y sonido con efecto aparte
            
            GameObject aux = Instantiate(explosion);
            aux.transform.position = this.transform.position;

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

    public void SetGodMode(bool value) => godMode = value;


    // check for bullet impacts (bullet = object with damage component)
    private void OnTriggerEnter(Collider other)
    {
        var damageComponent = other.gameObject.GetComponent<DamageComponent>();
        if (damageComponent != null && !this.CompareTag(other.tag) && !bulletImmunity)
        {
            TakeDamage(damageComponent.GetDamage());
        }
    }


    //TODO: on asteroid clash sound/effect
    //TODO: die if clash with Static tag
    private void OnCollisionEnter(Collision collision)
    {
        if (godMode && collision.transform.CompareTag("Static")) StartCoroutine(ColliderDesactivation());
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
