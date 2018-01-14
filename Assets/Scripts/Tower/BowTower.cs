using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTower : Tower
{
    const float bulletSpeed = 100f;
    [SerializeField] GameObject bullet;

    public override void Shoot(Transform enemy, Quaternion lookAngle, Vector3 delta, Vector3 hunterPos)
    {
        var force = delta.normalized * bulletSpeed;
        var bul = Instantiate(bullet);
        bul.transform.position = hunterPos;
        bul.transform.rotation = lookAngle;
        bul.GetComponent<Bullet>().SetIsTower(true);
        bul.GetComponent<Rigidbody>().AddForce(force);
        Destroy(bul, 4f);
    }

    public override float GetFiringDelay()
    {
        return 0.4f;
    }

    public override int GetCost()
    {
        return 50;
    }
}
