using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour {
	
	public void press(){
		SceneManager.LoadScene ("DarkGrass", LoadSceneMode.Single);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
