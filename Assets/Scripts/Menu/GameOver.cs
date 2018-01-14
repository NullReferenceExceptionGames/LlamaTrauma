using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 10f) {
			SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		}
	}
}
