using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToGame : MonoBehaviour {

	public void back(){
		var settings = GameObject.FindGameObjectWithTag ("Settings");
		Destroy (settings);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
