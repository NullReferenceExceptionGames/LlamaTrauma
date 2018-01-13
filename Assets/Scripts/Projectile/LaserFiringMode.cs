using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFiringMode : FiringMode
{
    GameObject pastLaser = null;

    public override void Fire(Vector3 direction, GameObject laser)
    {
        if (pastLaser != null)
        {
            pastLaser.SetActive(false);
        }
        pastLaser = laser;

        var startPoint = Camera.main.transform.position;
        Vector3 endPoint;
        var ray = new Ray(startPoint, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            endPoint = hit.point;
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<Enemy>().TakeDamage(1);
            }
        }
        else
        {
            endPoint = Camera.main.transform.position + (direction * 1000f);
        }

        laser.transform.position = (startPoint + endPoint) / 2;
        laser.transform.rotation = Quaternion.LookRotation(direction);
        var height = (endPoint - startPoint).magnitude;
        laser.transform.localScale = new Vector3(1, height, 1);

        pastLaser = laser;
    }

    public override float GetRepeatTimeSeconds()
    {
        return 0.03f;
    }

    public override string GetProjectileName()
    {
        return "Laser";
    }
}
