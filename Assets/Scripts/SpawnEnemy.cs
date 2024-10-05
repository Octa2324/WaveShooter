using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    private float timeBetweenSpawn = 5f;
    private float spawnTime;

    private int maxEnemies = 5;
    private int count = 0;
    private int killCount = 0;

    void Start()
    {
        spawnTime = Time.time + timeBetweenSpawn;
    }


    void Update()
    {
        if(Time.time > spawnTime && count < maxEnemies)
        {
            SpawnRegularEnemy();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnRegularEnemy()
    {
        Instantiate(enemy);
        count++;
    }

    public void OnEnemyDestroyed()
    {
        killCount++;
    }

    public int getKillCount()
    {
        return killCount;
    }
}
