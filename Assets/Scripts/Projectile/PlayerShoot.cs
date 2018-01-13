using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    FiringState state = FiringState.BOMB;
    [SerializeField] GameObject normalBullet;
    [SerializeField] GameObject bomb;

    public void Shoot()
    {
        var ray = Camera.main.transform.rotation * Vector3.forward;
        switch (state)
        {
            case FiringState.NORMAL:
                var bullet = Instantiate(normalBullet);
                bullet.GetComponent<Bullet>().SetIsTower(false);
                NormalFire(bullet, ray * 100f);
                break;
            case FiringState.BOMB:
                var bombInstance = Instantiate(bomb);
                NormalFire(bombInstance, ray * 50f);
                break;
        }
    }

    void NormalFire(GameObject proj, Vector3 force)
    {
        proj.transform.position = Camera.main.transform.position;
        proj.transform.rotation = Quaternion.LookRotation(force);
        proj.GetComponent<Rigidbody>().AddForce(force);
    }
}
