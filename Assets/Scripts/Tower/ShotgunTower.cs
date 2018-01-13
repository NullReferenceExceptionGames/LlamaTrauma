using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTower : Tower
{
    const float bulletSpeed = 30f;
    const int numBullets = 5;
    [SerializeField] GameObject hunter;
    [SerializeField] GameObject bullet;

    public override void Shoot(Transform enemy)
    {
        var delta = enemy.position - hunter.transform.position;
        var force = delta.normalized * bulletSpeed;
        var lookAngle = Quaternion.LookRotation(delta);
        for (var i = 0; i < numBullets; i++)
        {
            var bul = Instantiate(bullet);
            bul.transform.position = hunter.transform.position;
            bul.transform.rotation = lookAngle;
            bul.GetComponent<Bullet>().SetIsTower(true);
            var randomAddition = new Vector3(randomVelocityAddition(), randomVelocityAddition(), randomVelocityAddition());
            var forceRandom = force + randomAddition;
            bul.GetComponent<Rigidbody>().AddForce(forceRandom);
            Destroy(bul, 4);
        }
        hunter.transform.rotation = lookAngle;
    }

    float randomVelocityAddition()
    {
        return Random.Range(-5f, 5f);
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
