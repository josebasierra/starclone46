using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public float damage = 1f;


    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if(tag != "Player")
            Debug.Log(tag);
    }
}
