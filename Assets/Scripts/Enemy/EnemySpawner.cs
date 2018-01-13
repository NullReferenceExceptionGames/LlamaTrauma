using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] float spawnsPerSecond;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 1f) < spawnsPerSecond * Time.deltaTime)
        {
            Instantiate(enemy);
        }
    }
}
