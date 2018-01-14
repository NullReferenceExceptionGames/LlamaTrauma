using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isTower;

    public void SetIsTower(bool isTowerIn)
    {
        isTower = isTowerIn;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(10);
            Destroy(gameObject);
        }
        else if (!isTower && other.tag == "Tower")
        {
            other.GetComponent<Tower>().HitByPlayer();
        }
    }
}
