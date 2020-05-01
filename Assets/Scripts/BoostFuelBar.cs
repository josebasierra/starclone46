using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostFuelBar : MonoBehaviour
{
    public Slider slider;
	public Image fill;

	public void setFuel(float fuel)
	{
		if (fuel == 10) {
			slider.maxValue = fuel;
			slider.value = fuel;
		}

		else {
			slider.value = fuel;
		}
		
	}
}


