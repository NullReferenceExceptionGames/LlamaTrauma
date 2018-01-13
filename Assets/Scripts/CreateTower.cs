using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{

    public GameObject tower;
    Camera cam;
    int towerCount = 0;
    int towerLimit = 10;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var touch = Input.GetTouch(0);
            var ray = cam.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Tower")
                {
                    var successor = hit.transform.GetComponent<Tower>().successor;
                    if (successor != null)
                    {
                        var newTower = Instantiate(successor);
                        newTower.transform.position = hit.transform.position;
                        newTower.transform.rotation = hit.transform.rotation;
                        Destroy(hit.transform.gameObject);
                    }
                }
                else
                {
                    if (towerCount < towerLimit)
                    {
                        tower = Instantiate(tower);
                        tower.transform.position = hit.point;
                        towerCount++;
                    }
                }
            }
        }
    }
}
