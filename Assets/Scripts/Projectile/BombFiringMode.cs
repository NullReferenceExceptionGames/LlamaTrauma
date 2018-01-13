using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFiringMode : FiringMode
{
    public override void Fire(Vector3 direction, GameObject bomb)
    {
        bomb.transform.position = Camera.main.transform.position;
        bomb.transform.rotation = Quaternion.LookRotation(direction);
        var force = direction * 20f;
        bomb.GetComponent<Rigidbody>().AddForce(force);
    }

    public override float GetRepeatTimeSeconds()
    {
        return 5f;
    }

    public override string GetProjectileName()
    {
        return "Bomb";
    }
}
