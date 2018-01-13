using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour
{

    public GameObject defaultTower;
    public int money = 100;
    Camera cam;
    int towerCount = 0;
    int towerLimit = 10;
    [SerializeField] Text moneyText;

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
                        if (CanPayForTower(successor))
                        {
                            var newTower = Instantiate(successor);
                            newTower.transform.position = hit.transform.position;
                            newTower.transform.rotation = hit.transform.rotation;
                            Destroy(hit.transform.gameObject);
                        }
                    }
                }
                else
                {
                    if (towerCount < towerLimit && CanPayForTower(defaultTower))
                    {
                        var tower = Instantiate(defaultTower);
                        tower.transform.position = hit.point;
                        towerCount++;
                    }
                }
            }
        }

        moneyText.text = "$" + money.ToString();
    }

    bool CanPayForTower(GameObject towerObject)
    {
        var cost = towerObject.GetComponent<Tower>().GetCost();
        var canPay = cost <= money;
        if (canPay)
        {
            money -= cost;
        }
        return canPay;
    }
}
