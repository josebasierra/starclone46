using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public int damage = 1;

    public float GetDamage() => damage;


    private void OnTriggerEnter(Collider other)
    {
        //explosion effect, particles...
        if(other.gameObject.tag != this.gameObject.tag)
            Destroy(this.gameObject);
    }
}
