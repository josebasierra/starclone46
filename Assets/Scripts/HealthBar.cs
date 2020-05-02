using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	Health healthComponent;
	float health;

	void Start() {
		healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		health = healthComponent.GetHealth();
	}

	void Update() {
		health = healthComponent.GetHealth();

		if (health == 100) {
			slider.maxValue = health;
			slider.value = health;

			fill.color = gradient.Evaluate(1f);
		}

		else {
			slider.value = health;

			fill.color = gradient.Evaluate(slider.normalizedValue);
		}
	}
}
