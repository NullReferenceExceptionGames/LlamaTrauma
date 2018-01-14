using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {

	public void menu(){
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
