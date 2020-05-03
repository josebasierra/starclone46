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
	float maxHealth;

	void Start() {
		healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		
		slider.maxValue = 1.0f;
		maxHealth = healthComponent.GetMaxHealth();
		fill.color = gradient.Evaluate(1f);
	}

	void Update() {
		float health = healthComponent.GetCurrentHealth();

		slider.value = health/maxHealth;
		Debug.Log(slider.value);

		fill.color = gradient.Evaluate(slider.normalizedValue);
		
	}
}
