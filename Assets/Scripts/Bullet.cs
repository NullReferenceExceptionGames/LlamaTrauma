using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        print(other.name);
        if (other.tag != "Tower")
        {
            Destroy(gameObject);
        }
    }
}
