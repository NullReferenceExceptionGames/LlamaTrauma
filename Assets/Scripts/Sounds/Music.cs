using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	[SerializeField] GameObject musicPlayer;
	//[SerializeField] AudioClip music;

	// Use this for initialization
	void Start () {
		var instances = GameObject.FindGameObjectsWithTag ("Music");
		//AudioSource audio = GetComponent<AudioSource>();
		DontDestroyOnLoad (musicPlayer);
		//music.

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
