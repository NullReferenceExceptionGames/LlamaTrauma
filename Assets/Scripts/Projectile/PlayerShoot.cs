using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    FiringMode firingMode;
    bool shoot = false;

    void Start()
    {
        firingMode = new NormalFiringMode();
    }

    public void StartShooting()
    {
        shoot = true;
        StartCoroutine(Shoot());
    }

    public void StopShooting()
    {
        shoot = false;
    }

    IEnumerator Shoot()
    {
        while (shoot)
        {
            var ray = Camera.main.transform.rotation * Vector3.forward;
            var projectileOriginal = GameObject.Find(firingMode.GetProjectileName());
            var projectile = Instantiate(projectileOriginal);
            firingMode.Fire(ray, projectile);
            yield return new WaitForSeconds(firingMode.GetRepeatTimeSeconds());
        }
    }
}
