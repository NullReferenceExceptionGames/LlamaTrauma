using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTower : Tower
{
    const float bulletSpeed = 100f;
    [SerializeField] GameObject hunter;
    [SerializeField] GameObject bullet;

    public override void Shoot(Transform enemy)
    {
        var delta = enemy.position - hunter.transform.position;
        var force = delta.normalized * bulletSpeed;
        var bul = Instantiate(bullet);
        bul.transform.position = hunter.transform.position;
        var lookAngle = Quaternion.LookRotation(delta);
        bul.transform.rotation = lookAngle;
        bul.GetComponent<Bullet>().SetIsTower(true);
        bul.GetComponent<Rigidbody>().AddForce(force);
        hunter.transform.rotation = lookAngle;
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
