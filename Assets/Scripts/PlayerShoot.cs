using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject projectile;

    public void Shoot()
    {
        var ray = Camera.main.transform.rotation * Vector3.forward;
        var proj = Instantiate(projectile);
        proj.transform.position = Camera.main.transform.position;
        proj.transform.rotation = Quaternion.LookRotation(ray);
        proj.GetComponent<Bullet>().SetIsTower(false);
        proj.GetComponent<Rigidbody>().AddForce(ray * 100f);
        Destroy(proj, 4);
    }
}
