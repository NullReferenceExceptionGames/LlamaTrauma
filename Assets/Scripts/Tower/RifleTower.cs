using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleTower : Tower
{
    public override void Shoot(Transform enemy, Quaternion _0, Vector3 _1, Vector3 _2)
    {
        enemy.GetComponent<Enemy>().TakeDamage(byte.MaxValue);
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
