using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;

    public AudioClip mainMenuClip;
    public AudioClip otherSceneClip;

    private AudioSource audioSource;

    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusicForCurrentScene();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }

    void PlayMusicForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu")
        {
            PlayMusic(mainMenuClip);
        }
        else
        {
            PlayMusic(otherSceneClip);
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (clip != null && audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
