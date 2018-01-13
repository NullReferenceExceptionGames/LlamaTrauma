using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{

    public abstract void Shoot(Vector3 position);

    void Update()
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
    }
}