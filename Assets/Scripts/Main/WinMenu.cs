using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;


    void FixedUpdate()
    {
        if (ScoreSystem.score >= WordTimer.scoreToWin)
        {
            User.IncreaseExp(WordTimer.expGive);
            
            switch (LevelLoader.staticDifficulty)
            {
                case "Easy":
                    User.EasyWins++;
                    break;
                case "Normal":
                    User.NormalWins++;
                    break;
                case "Hard":
                    User.HardWins++;
                    break;
                case "Insane":
                    User.InsaneWins++;
                    break;
            }
            
            PauseMenu.GameIsPaused = true;
            Pause();
            if (ScoreSystem.score > User.HighScore)
            {
                User.HighScore = ScoreSystem.score;
                ScoreSystem.NewHighScore = true;
            }
            else
                ScoreSystem.NewHighScore = false;
        }
    }

    void Pause()
    {
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
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