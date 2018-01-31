using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFiringMode : FiringMode
{
    public override void Fire(Vector3 direction, GameObject bullet)
    {
        bullet.GetComponent<Bullet>().SetIsTower(false);
        bullet.transform.position = Camera.main.transform.position;
        bullet.transform.rotation = Quaternion.LookRotation(direction);
        var force = direction * 150f;
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
