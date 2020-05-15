using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public float damage = 1f;

    public float GetDamage() => damage;


    private void OnTriggerEnter(Collider other)
    {
        //explosion effect, particles...
        if(!CompareTag(other.gameObject.tag))
            Destroy(this.gameObject);
    }
}
