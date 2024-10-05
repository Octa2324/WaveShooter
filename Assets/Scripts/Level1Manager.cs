using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public GameObject nextLevelCanvas;
    public GameObject gameOverCanvas;
    private SpawnEnemy enemy;

    void Start()
    {
        enemy = FindObjectOfType<SpawnEnemy>();

        if(nextLevelCanvas != null)
        {
            nextLevelCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (enemy != null && enemy.getKillCount() == 5)
        {
            ShowGameOverScreen();
        }
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    void ShowGameOverScreen()
    {
        if(nextLevelCanvas != null)
        {
            nextLevelCanvas.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
