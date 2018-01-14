using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene4 : MonoBehaviour {

	public void press(){
		SceneManager.LoadScene ("Snow", LoadSceneMode.Single);
	}

	// Update is called once per frame
	void Update () {

	}
}
