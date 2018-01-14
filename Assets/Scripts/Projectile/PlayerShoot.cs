using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool shoot = false;
    FiringMode firingMode;

    void Start()
    {
        firingMode = new NormalFiringMode();
        StartCoroutine(Shoot());
    }

    public void StartShooting()
    {
        shoot = true;
    }

    public void StopShooting()
    {
        shoot = false;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            while (shoot)
            {
                GetComponent<AudioSource>().Play();

                var ray = Camera.main.transform.rotation * Vector3.forward;
                var projectileOriginal = GameObject.Find(firingMode.GetProjectileName());
                var projectile = Instantiate(projectileOriginal);
                firingMode.Fire(ray, projectile);
                Destroy(projectile, 4);
                yield return new WaitForSeconds(firingMode.GetRepeatTimeSeconds());
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
