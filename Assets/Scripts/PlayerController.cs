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

    private SoundEffectsPlayer soundEffectsPlayer;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        soundEffectsPlayer = FindObjectOfType<SoundEffectsPlayer>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (movement.magnitude > 0.01f)
        {
            soundEffectsPlayer.Walk();
        }
        else
        {
            soundEffectsPlayer.StopWalk();
        }

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
        if (isDead) return;
        isDead = true;
        movement = Vector2.zero;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        soundEffectsPlayer.PlayerDieSound();
        soundEffectsPlayer.StopWalk();
        if (spawnEnemy != null)
        {
            spawnEnemy.StopSpawning();
            Debug.Log("Stopped spawning enemies because player died.");
        }

        StartCoroutine(DelayedDestroy()); ;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.Die();
        }
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(1f); 
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if (isDead) return;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
