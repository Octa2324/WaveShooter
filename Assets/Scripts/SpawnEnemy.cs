using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    private float timeBetweenSpawn = 10f;
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time + timeBetweenSpawn;
    }


    void Update()
    {
        if(Time.time > spawnTime)
        {
            SpawnRegularEnemy();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnRegularEnemy()
    {
        Instantiate(enemy);
    }
}
