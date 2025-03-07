using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mouse;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private int maxBullets = 30;
    private static int currentBullets = 10;

    public TextMeshPro gloante;
    public GameObject ammoDrop;
    private bool hasSpawned = false;

    public TextMeshProUGUI nr;

    private SoundEffectsPlayer soundEffectsPlayer;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        UpdateBulletDisplay();
        soundEffectsPlayer = FindObjectOfType<SoundEffectsPlayer>();
    }

    void Update()
    {
        UpdateBulletDisplay();

        Vector3 direction = mouse - transform.position;

        mouse = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mouse - transform.position; 
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire && currentBullets < maxBullets && currentBullets > 0)
        {
            canFire = false;
            FireBullet();
        }

        if(direction.x >= 0.01f)
        {
            bulletTransform.localScale = new Vector3(0.05f, 0.05f, 1f);
            gloante.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(direction.x <= -0.01f)
        {
            bulletTransform.localScale = new Vector3(0.05f, -0.05f, 1f);
            gloante.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if(currentBullets == 0 && hasSpawned == false)
        {
            SpawnAmmoDrop();
            hasSpawned = true;
        }

    }

    void FireBullet()
    {
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        soundEffectsPlayer.Shoot();
        currentBullets--;
        UpdateBulletDisplay();
    }

    public static void DecreaseBulletCount()
    {
        if (currentBullets > 0)
        {
            currentBullets--;
        }
    }

    public static void IncreaseBulletCount(int amount)
    {
        currentBullets = Mathf.Clamp(currentBullets + amount, 0, 20); 
    }

    private void UpdateBulletDisplay()
    {
        gloante.text =currentBullets.ToString();
        nr.text = gloante.text;
    }

    private void SpawnAmmoDrop()
    {
        if (!GameObject.FindWithTag("AmmoDrop"))
        {
            GameObject newAmmoDrop = Instantiate(ammoDrop);
            StartCoroutine(FadeIn(newAmmoDrop));
        }
    }

    private IEnumerator FadeIn(GameObject obj)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            float duration = 1.0f;  
            float elapsedTime = 0f;
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
            while (elapsedTime < duration)
            {
                if (spriteRenderer == null) yield break; 

                elapsedTime += Time.deltaTime;
                color.a = Mathf.Clamp01(elapsedTime / duration);  
                spriteRenderer.color = color;
                yield return null;
            }
            color.a = 1f;
            spriteRenderer.color = color;
        }
    }

    public static void ResetShootingState()
    {
        currentBullets = 10;
    }

}
