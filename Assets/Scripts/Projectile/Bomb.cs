using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    const float damageAtOneUnit = 20f;
    [SerializeField] GameObject renderer;

    void OnTriggerEnter(Collider _)
    {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            var distance = (enemy.transform.position - transform.position).magnitude;
            enemy.GetComponent<Enemy>().TakeDamage((byte)Mathf.Round(damageAtOneUnit / distance));
        }
        renderer.SetActive(false);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<ParticleSystem>().Play();
    }
}
