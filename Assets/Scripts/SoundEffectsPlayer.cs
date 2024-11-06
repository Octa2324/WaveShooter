using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip shoot, enemySpawn, enemyDie, playerDie;

    public void Shoot()
    {
        src.clip = shoot;
        src.Play();
    }
    public void EnemySpawnSound()
    {
        src.clip = enemySpawn;
        src.Play();
    }
    public void EnemyDieSound()
    {
        src.clip = enemyDie;
        src.Play();
    }
    public void PlayerDieSound()
    {
        src.clip = playerDie;
        src.Play();
    }
}
