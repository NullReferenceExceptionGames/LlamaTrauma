using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

	Slider volumeSlider;

	// Use this for initialization
	 
	void Start () {
		volumeSlider.value = AudioListener.volume;
	}
	
	public void OnValueChanged(){
		AudioListener.volume = volumeSlider.value;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
