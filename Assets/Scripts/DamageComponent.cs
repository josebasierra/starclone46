using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public int damage = 1;


    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if(tag != this.gameObject.tag)
        {
            var stats = other.gameObject.GetComponent<PlayerStats>();
            if (stats != null) stats.takeDamage(damage);
        }
    }
}
