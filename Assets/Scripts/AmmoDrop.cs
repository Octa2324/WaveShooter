using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    private int bulletAmount = 20;
    private SoundEffectsPlayer soundEffectsPlayer;

    void Start()
    {
        soundEffectsPlayer = FindObjectOfType<SoundEffectsPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundEffectsPlayer.PickUpBook();

            Shooting.IncreaseBulletCount(bulletAmount);

            Destroy(gameObject);
        }
    }
}
