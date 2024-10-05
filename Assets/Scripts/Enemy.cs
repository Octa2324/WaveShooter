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


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        aiDestinationSetter.target = player.transform;
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1f);
        }else if(aiPath.desiredVelocity.x <= -0.01)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage; ;
        if (health <= 0)
        {
            SpawnEnemy spawner = FindObjectOfType<SpawnEnemy>();
            if (spawner != null)
            {
                spawner.OnEnemyDestroyed();
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
    }

  

}
