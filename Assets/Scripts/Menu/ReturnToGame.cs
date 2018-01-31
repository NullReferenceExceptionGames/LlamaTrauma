using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToGame : MonoBehaviour
{

    public void back()
    {
        Camera.main.GetComponent<CreateTower>().menuEnabled = false;
        var settings = GameObject.FindGameObjectsWithTag("Settings");
        foreach (var i in settings)
        {
            Destroy(i);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
