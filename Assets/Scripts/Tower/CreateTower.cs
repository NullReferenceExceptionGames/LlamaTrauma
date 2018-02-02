using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CreateTower : MonoBehaviour
{

    public GameObject defaultTower;
    public bool menuEnabled = false;
    public int money;
    int health = 100;
    Camera cam;
    int towerCount = 0;
    bool winB = false;
    int towerLimit = 10;
    Text timeText;
    [SerializeField] Text moneyText;
    [SerializeField] Text healthText;
    [SerializeField] GameObject win;
    [SerializeField] GameObject winVoxel;
    [SerializeField] GameObject canvas;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
        StartCoroutine(CreateTowers());
    }

    // Update is called once per frame
    IEnumerator CreateTowers()
    {
        var shoot = GameObject.FindGameObjectWithTag("Shoot").GetComponent<PlayerShoot>();
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (shoot.shoot || menuEnabled)
                {
                    continue;
                }

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
                        }
                    }
                }
            }

            moneyText.text = money.ToString();

            var timeLeft = 180 - (int)Time.timeSinceLevelLoad;
            var seconds = timeLeft % 60;
            var minutes = timeLeft / 60;
            var secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
            timeText.text = timeLeft > 0 ? minutes.ToString() + ":" + secondsString : "0:00";
            if (Time.timeSinceLevelLoad >= 180f && winB != true)
            {
                Instantiate(winVoxel);
                winB = true;
            }
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
        healthText.text = health.ToString();// + " HP";
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
