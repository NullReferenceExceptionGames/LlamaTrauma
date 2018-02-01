using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] GameObject sceneModel;
    [SerializeField] GameObject sceneModel2;
    [SerializeField] Text StoryText;
    bool onSecondDescription = false;

    // Use this for initialization
    void Start()
    {
        Instantiate(sceneModel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (onSecondDescription)
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
            else
            {
                var scene1 = GameObject.FindGameObjectsWithTag("Scene");
                foreach (var i in scene1)
                {
                    Destroy(i);
                }
                Instantiate(sceneModel2);
                StoryText.text = "They envision a world populated by llamas, farming humans for our hair. We will not submit. We will rid ourselves of this llama scourge and see peace again.";
                onSecondDescription = true;
            }
        }
    }
}
