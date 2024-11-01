using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    private int bulletAmount = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Shooting.IncreaseBulletCount(bulletAmount);

            Destroy(gameObject);
        }
    }
}
