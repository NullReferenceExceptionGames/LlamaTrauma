using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleTower : Tower
{
    [SerializeField] GameObject hunter;

    public override void Shoot(Transform enemy)
    {
        enemy.GetComponent<Enemy>().TakeDamage(byte.MaxValue);
        var delta = enemy.position - transform.position;
        var lookAngle = Quaternion.LookRotation(delta);
        hunter.transform.rotation = lookAngle;
    }

    public override float GetFiringDelay()
    {
        return 5f;
    }

    public override int GetCost()
    {
        return 20;
    }
}
