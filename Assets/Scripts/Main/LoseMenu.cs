using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject LoseMenuUI;
    public CameraShake cameraShake;


    void FixedUpdate()
    {
        if (CollisionDetection.GameOver)
        {
            StartCoroutine(cameraShake.Shake(2f, -0.1f));
            if (ScoreSystem.score > ScoreSystem.highScore)
            {
                ScoreSystem.highScore = ScoreSystem.score;
                ScoreSystem.NewHighScore = true;
            }
            else
                ScoreSystem.NewHighScore = false;
            
            PauseMenu.GameIsPaused = true;
            Pause();
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        LoseMenuUI.SetActive(false);
        CollisionDetection.GameOver = false;
        SceneManager.LoadScene("Main");
    }
    void Pause()
    {
        LoseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadLevels()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        LoseMenuUI.SetActive(false);
        CollisionDetection.GameOver = false;
        SceneManager.LoadScene("Menu");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        CollisionDetection.GameOver = false;
        SceneManager.LoadScene("LoadingScreen");
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        Application.Quit();
    }
}
