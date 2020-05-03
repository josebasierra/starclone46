using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostFuelBar : MonoBehaviour
{
    public Slider slider;
	public Image fill;
	
	PlayerMovement moveComponent;


	void Start() {
		moveComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		slider.maxValue = 1.0f;
	}


	void Update() {
		float currentFuel = moveComponent.GetCurrentFuel();
		float maxFuel = moveComponent.GetMaxFuel();

		slider.value = currentFuel / maxFuel;
	}
}


