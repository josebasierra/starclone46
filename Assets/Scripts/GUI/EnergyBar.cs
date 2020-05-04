using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
	public Image fill;

	Energy energy;


	void Start() {
		energy = GameObject.FindGameObjectWithTag("Player").GetComponent<Energy>();
		slider.maxValue = 1.0f;
	}


	void Update() {
		float currentFuel = energy.GetCurrentEnergy();
		float maxFuel = energy.GetMaxEnergy();

		slider.value = currentFuel / maxFuel;
	}
}


