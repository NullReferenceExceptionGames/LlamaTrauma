using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFiringMode : FiringMode
{
    public override void Fire(Vector3 direction, GameObject bullet)
    {
        bullet.GetComponent<Bullet>().SetIsTower(false);
        bullet.transform.position = Camera.main.transform.position;
        var force = direction * 100f;
        bullet.transform.rotation = Quaternion.LookRotation(force);
        bullet.GetComponent<Rigidbody>().AddForce(force);

    }

    public override float GetRepeatTimeSeconds()
    {
        return 0.5f;
    }

    public override string GetProjectileName()
    {
        return "NormalBullet";
    }
}
