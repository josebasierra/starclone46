using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 1f;
    bool damageApplied = false;

    public float GetDamage() {
        if (!damageApplied)
        {
            damageApplied = true;
            return damage;
        }
        else return 0f;
    }


    private void OnTriggerEnter(Collider other)
    {
        //explosion effect, particles...
        if(!CompareTag(other.gameObject.tag))
            Destroy(this.gameObject);
    }
}
