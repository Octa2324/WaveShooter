using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 3.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    private SpawnEnemy spawnEnemy;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spawnEnemy = FindObjectOfType<SpawnEnemy>();
    }

    void Update()
    {
        if (movement.x >= 0.01f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else if (movement.x <= -0.01f)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
        }
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        if (spawnEnemy != null)
        {
            spawnEnemy.StopSpawning();
            Debug.Log("Stopped spawning enemies because player died.");
        }
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.Die();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
