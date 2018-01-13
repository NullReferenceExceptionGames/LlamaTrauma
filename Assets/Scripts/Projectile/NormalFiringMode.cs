using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFiringMode : FiringMode
{
    protected override void Fire(Vector3 direction)
    {
        var bullet = Instantiate(normalBullet);
        bullet.GetComponent<Bullet>().SetIsTower(false);
        NormalFire(bullet, ray * 100f);

    }
}
