using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	[SerializeField] GameObject musicPlayer;

	void Start () {
		var instances = GameObject.FindGameObjectsWithTag ("Music");
		if (instances.Length > 1) {
			Destroy (musicPlayer);
		}
		DontDestroyOnLoad (musicPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
