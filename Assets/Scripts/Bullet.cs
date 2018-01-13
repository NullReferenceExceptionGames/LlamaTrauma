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
        if (other.tag != "Tower")
        {
            Invoke("Terminate", 0.1f);
        }
        else if (!isTower)
        {
            other.GetComponent<Tower>().HitByPlayer();
        }
    }

    void Terminate()
    {
        Destroy(gameObject);
    }

    public enum Sender
    {
        PLAYER,
        TOWER
    }
}
