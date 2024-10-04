using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Vector3 mouse;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mouse = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouse - transform.position;
        Vector3 rotation = transform.position - mouse;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Collider2D bulletCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(bulletCollider, playerCollider);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Collision with: " + collision.gameObject.name);

        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
