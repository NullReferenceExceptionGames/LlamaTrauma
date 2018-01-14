using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToGame : MonoBehaviour {

	public void back(){
		var settings = GameObject.FindGameObjectsWithTag ("Settings");
		foreach (var i in settings) {
			Destroy (i);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
