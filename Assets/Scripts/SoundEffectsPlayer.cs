using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src; // For general SFX
    public AudioSource walkSource; // For walking SFX
    public AudioClip shoot, enemySpawn, enemyDie, playerDie, walk, pickUp;
    private bool isWalking = false;

    public void Shoot()
    {
        src.PlayOneShot(shoot);
    }
    public void EnemySpawnSound()
    {
        src.PlayOneShot(enemySpawn);
    }
    public void EnemyDieSound()
    {
        src.PlayOneShot(enemyDie);
    }
    public void PlayerDieSound()
    {
        src.PlayOneShot(playerDie);
    }
    public void PickUpBook()
    {
        src.PlayOneShot(pickUp);
    }
    public void Walk()
    {
        if (!isWalking)
        {
            walkSource.clip = walk;
            walkSource.loop = true;
            walkSource.Play();
            isWalking = true;
        }
    }
    public void StopWalk()
    {
        if (isWalking)
        {
            walkSource.loop = false;
            walkSource.Stop();
            isWalking = false;
        }
    }
}
