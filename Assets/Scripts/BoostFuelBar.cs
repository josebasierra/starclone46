using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostFuelBar : MonoBehaviour
{
    public Slider slider;
	public Image fill;
	
	PlayerMovement moveComponent;

	float fuel;

	void Start() {
		moveComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		fuel = moveComponent.getFuel();
	}

	void Update() {
		fuel = moveComponent.getFuel();
		if (fuel == 10.0) {
			slider.maxValue = fuel;
			slider.value = fuel;
		}

		else {
			slider.value = fuel;
		}
	}
}


