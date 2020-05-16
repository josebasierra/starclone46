using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 1f;
    bool hasDamaged = false;


    public float GetDamage() => damage;

    public bool SetHasDamaged(bool value) => hasDamaged = value;

    public bool GetHasDamaged() => hasDamaged;


    private void OnTriggerEnter(Collider other)
    {
        //explosion effect, particles...
        if(!CompareTag(other.gameObject.tag))
            Destroy(this.gameObject);
    }
}
