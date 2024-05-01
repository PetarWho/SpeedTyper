using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;
    [SerializeField] private TextMeshProUGUI WinText;
    [SerializeField] private TextMeshProUGUI PerfectText;

    public static bool PerfectGame;

    private void Start()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        WinMenuUI.SetActive(false);
        CollisionDetection.GameOver = false;
        PerfectText.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (ScoreSystem.score >= WordTimer.scoreToWin)
        {
            User.IncreaseExp(WordTimer.expGive);

            string currentDifficulty = LevelLoader.staticDifficulty;
            
            switch (currentDifficulty)
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

            if (int.TryParse(currentDifficulty, out int level))
            {
                if (User.CampaignLevel < level)
                {
                    User.CampaignLevel = level;
                }
                WinText.text = $"You completed campaign level {level}";
                if (PerfectGame) PerfectText.gameObject.SetActive(true);
            }
            else
            {
                WinText.text = $"You won on {currentDifficulty} difficulty";
                if (PerfectGame) PerfectText.gameObject.SetActive(true);
            }

            if (PerfectGame)
            {
                User.PerfectGames++;
            }

            SaveSystem.Save();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    void Pause()
    {
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
    }
}