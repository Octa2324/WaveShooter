using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    private GameObject player;
    private float health = 20;
    private AIDestinationSetter aiDestinationSetter;
    public AIPath aiPath;

    private Animator animator;
    private bool isDead = false;

    private SoundEffectsPlayer soundEffectsPlayer;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        aiDestinationSetter.target = player.transform;

        animator = GetComponent<Animator>();
        soundEffectsPlayer = FindObjectOfType<SoundEffectsPlayer>();
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(5f, 5f, 1f);
        }else if(aiPath.desiredVelocity.x <= -0.01)
        {
            transform.localScale = new Vector3(-5f, 5f, 1f);
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !isDead)
        {
            Die();
            soundEffectsPlayer.EnemyDieSound();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Die");
        aiPath.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f); 
        SpawnEnemy spawner = FindObjectOfType<SpawnEnemy>();
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
