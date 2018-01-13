using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTower : Tower
{
    const float bulletSpeed = 100f;

    [SerializeField] GameObject bullet;

    public override void Shoot(Vector3 position)
    {
        var delta = position - transform.position;
        var force = delta.normalized * bulletSpeed;
        var bul = Instantiate(bullet);
        bul.transform.position = transform.position;
        bul.transform.rotation = Quaternion.LookRotation(delta);
        bul.GetComponent<Rigidbody>().AddForce(force);
    }

    public override float GetFiringDelay()
    {
        return 0.4f;
    }
}
