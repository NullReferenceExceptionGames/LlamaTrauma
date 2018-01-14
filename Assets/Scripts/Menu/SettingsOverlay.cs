using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOverlay : MonoBehaviour {

	[SerializeField] GameObject overlay;
	[SerializeField] GameObject canvas;
	[SerializeField] GameObject voxel;

	public void OverLay(){
		GameObject settings = Instantiate (overlay, canvas.transform);
		settings.transform.SetParent (canvas.transform);


		//settings.transform.position = new Vector3 (0,0,0);
		//settings.transform.position = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
