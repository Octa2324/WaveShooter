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

    public Transform[] spawnPositions;

    private bool playerIsAlive = true;

    void Start()
    {
        spawnTime = Time.time + timeBetweenSpawn;
    }


    void Update()
    {
        if(playerIsAlive && Time.time > spawnTime && count < maxEnemies)
        {
            SpawnRegularEnemy();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnRegularEnemy()
    {
        if (spawnPositions.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnLocation = spawnPositions[randomIndex].position;

            Instantiate(enemy, spawnLocation, Quaternion.identity);
            count++;
        }
    }

    public void OnEnemyDestroyed()
    {
        killCount++;
    }

    public int getKillCount()
    {
        return killCount;
    }

    public void StopSpawning()
    {
        playerIsAlive = false;
    }
}
