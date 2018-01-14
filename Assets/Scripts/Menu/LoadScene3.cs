using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene3 : MonoBehaviour {
	
	public void press(){
		SceneManager.LoadScene ("Beach", LoadSceneMode.Single);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
