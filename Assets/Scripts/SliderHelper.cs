using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class SliderHelper : MonoBehaviour {

	private Slider slider;
	public Text sliderValue;

	void Start(){
		slider = transform.GetComponent<Slider> ();
	}

	public void UpdateSliderValue () {
		sliderValue.text = slider.value.ToString();
	}
}
