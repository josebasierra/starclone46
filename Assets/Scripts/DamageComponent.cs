using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public int damage = 1;


    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        if(otherTag != this.gameObject.tag)
        {
            var health = other.gameObject.GetComponent<Health>();
            if (health != null) health.takeDamage(damage);
        }
    }
}
