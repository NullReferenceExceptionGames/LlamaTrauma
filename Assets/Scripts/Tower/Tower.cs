using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public abstract void Shoot(Vector3 position);

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
                var closestEnemyPosition = Vector3.zero;
                var dis = 1000f;
                foreach (var enemy in enemies)
                {
                    var tmpDis = Vector3.Distance(transform.position, enemy.transform.position);
                    if (tmpDis < dis)
                    {
                        dis = tmpDis;
                        closestEnemyPosition = enemy.transform.position;
                    }
                }
                Shoot(closestEnemyPosition);
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