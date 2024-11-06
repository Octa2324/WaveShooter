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
    private CanvasGroup nextLevelCanvasGroup;

    void Start()
    {
        enemy = FindObjectOfType<SpawnEnemy>();

        if (nextLevelCanvas != null)
        {
            nextLevelCanvas.SetActive(false);
            nextLevelCanvasGroup = nextLevelCanvas.GetComponent<CanvasGroup>();
            nextLevelCanvasGroup.alpha = 0;
        }

        gameOverCanvasGroup = gameOverCanvas.GetComponent<CanvasGroup>();
        gameOverCanvasGroup.alpha = 0;
        gameOverCanvas.SetActive(false);

        if (TargetCursor.Instance != null)
        {
            TargetCursor.Instance.ShowCursor(false);
        }
    }

    void Update()
    {
        if (enemy != null && enemy.getKillCount() == 5 && GameObject.FindGameObjectWithTag("Player") != null)
        {
            ShowNextLevelScreen();
        }
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverCanvas.SetActive(true);
            if (TargetCursor.Instance != null)
            {
                TargetCursor.Instance.ShowCursor(true);
            }
            StartCoroutine(FadeInGameOverScreen());
        }
    }

    void ShowNextLevelScreen()
    {
        if (nextLevelCanvas != null)
        {
            nextLevelCanvas.SetActive(true);
            if (TargetCursor.Instance != null)
            {
                TargetCursor.Instance.ShowCursor(true);
            }
            StartCoroutine(FadeInNextLevelScreen());
        }
    }

    public void Restart()
    {
        Shooting.ResetShootingState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (TargetCursor.Instance != null)
        {
            TargetCursor.Instance.ShowCursor(false);
        }
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

    private IEnumerator FadeInNextLevelScreen()
    {
        float duration = 1.0f;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            nextLevelCanvasGroup.alpha = Mathf.Lerp(0, 1, time / duration);
            yield return null;
        }

        nextLevelCanvasGroup.alpha = 1;
    }
}
