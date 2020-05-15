﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float maxEnergy;
    public float energyPerSecond;
    public float rechargeEnergy = 20f;
    [Range(0,1)] public float cooldownThreshold;

    float currentEnergy;
    bool onCooldown;


    public float GetMaxEnergy() => maxEnergy;
    public float GetCurrentEnergy() => currentEnergy;
    public bool isOnCooldown() => onCooldown;

    public bool Consume(float value)
    {
        if (onCooldown) return false;
        else
        {
            currentEnergy -= value;
            return true;
        }
    }

    public void Recharge() {
    	currentEnergy = Mathf.Min(currentEnergy + rechargeEnergy, maxEnergy);
    }


    void Start()
    {
        currentEnergy = maxEnergy;
    }


    void Update()
    {
        currentEnergy += energyPerSecond * Time.deltaTime;
        currentEnergy = Mathf.Min(currentEnergy, maxEnergy);

        if (currentEnergy >= cooldownThreshold * maxEnergy) { onCooldown = false; }
        else if (currentEnergy <= 0)
        {
            onCooldown = true;
            currentEnergy = 0f;
        }
    }
}
