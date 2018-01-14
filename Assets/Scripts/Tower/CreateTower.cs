using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateTower : MonoBehaviour
{

    public GameObject defaultTower;
    public int money;
    int health = 1;
    Camera cam;
    int towerCount = 0;
	bool winB = false;
    int towerLimit = 10;
    [SerializeField] Text moneyText;
    [SerializeField] Text healthText;
	[SerializeField] GameObject win;
	[SerializeField] GameObject canvas;

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
                        var parent = GameObject.FindGameObjectWithTag("EnemyPath");
                        var pathPointTransforms = parent.GetComponentsInChildren<Transform>().ToList();
                        pathPointTransforms.Remove(parent.transform);
						var tower = Instantiate(defaultTower);
						tower.transform.position = hit.point;
						towerCount++;
						// foreach (var point in pathPointTransforms)
                        //{
                        //1.479f Smaller Number closer
                        //                            if (Vector3.Distance(point.transform.position, transform.position) > 1.471f && CanPayForTower(defaultTower))
                        //                            {
                        //                                var tower = Instantiate(defaultTower);
                        //                                tower.transform.position = hit.point;
                        //                                towerCount++;
                        //                            }
                        //}
                    }
                }
            }
        }
        moneyText.text = /*"$" +*/ money.ToString();
		if (Time.timeSinceLevelLoad >= 5f && winB != true) {
			GameObject settings = Instantiate (win, canvas.transform);
			winB = true;
		}
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

    public void TakeDamage(int damage)
    {
        health -= damage;
		healthText.text = health.ToString ();// + " HP";
		if (health <= 0) {
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
    }
}
