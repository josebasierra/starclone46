using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public int damage = 1;

    public float GetDamage() => damage;

    //TODO: Ignore owner impact
    private void OnTriggerEnter(Collider other)
    {
        //explosion effect, particles...
        Destroy(this.gameObject);
    }
}
