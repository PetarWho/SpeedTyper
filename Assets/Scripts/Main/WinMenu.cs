using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;


    // void FixedUpdate()
    // {
    //     if(GameWon)
    //         if (ScoreSystem.score > ScoreSystem.highScore)
    //         {
    //             ScoreSystem.highScore = ScoreSystem.score;
    //             ScoreSystem.NewHighScore = true;
    //         }
    //         else
    //             ScoreSystem.NewHighScore = false;
    //         
    //         PauseMenu.GameIsPaused = true;
    //         Pause();
    //     
    // }
    void Pause()
    {
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadLevels()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        WinMenuUI.SetActive(false);
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
