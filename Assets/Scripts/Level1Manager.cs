using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public GameObject nextLevelCanvas;
    public GameObject gameOverCanvas;
    private SpawnEnemy enemy;

    private CanvasGroup gameOverCanvasGroup;

    void Start()
    {
        enemy = FindObjectOfType<SpawnEnemy>();

        if(nextLevelCanvas != null)
        {
            nextLevelCanvas.SetActive(false);
        }

        gameOverCanvasGroup = gameOverCanvas.GetComponent<CanvasGroup>();
        gameOverCanvasGroup.alpha = 0; 
        gameOverCanvas.SetActive(false);
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
            StartCoroutine(FadeInGameOverScreen());
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

    private IEnumerator FadeInGameOverScreen()
    {
        float duration = 1.0f; 
        float time = 0; 

        while (time < duration)
        {
            time += Time.deltaTime;
            gameOverCanvasGroup.alpha = Mathf.Lerp(0, 1, time / duration); 
            yield return null; 
        }

        gameOverCanvasGroup.alpha = 1; 
    }

   

}
