using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public abstract void Shoot(Transform enemy);

    public abstract float GetFiringDelay();
    public abstract int GetCost();

    public GameObject successor;

    private int hitsByPlayerBeforeSale = 3;

    void Start()
    {
        StartCoroutine(ShootLoop());
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                Transform closestEnemy = null;
                var dis = 1000f;
                foreach (var enemy in enemies)
                {
                    var tmpDis = Vector3.Distance(transform.position, enemy.transform.position);
                    if (tmpDis < dis)
                    {
                        dis = tmpDis;
                        closestEnemy = enemy.transform;
                    }
                }
                Shoot(closestEnemy);
            }
            yield return new WaitForSeconds(GetFiringDelay());
        }
    }

    public void HitByPlayer()
    {
        hitsByPlayerBeforeSale--;
        if (hitsByPlayerBeforeSale <= 0)
        {
            Camera.main.GetComponent<CreateTower>().money += GetCost();
            Destroy(gameObject);
        }
    }
}