using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScorePoints : MonoBehaviour
{
    public int points = 25;
    Health health;
    

    void Start()
    {
        health = GetComponent<Health>();
        if (health != null) health.OnDeath += OnDeath;
    }


    void OnDisable()
    {
        if (health != null) health.OnDeath += OnDeath;
    }


    void OnDeath()
    {
        GameManager.instance.AddScore(points);
    }
}
