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
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        WinMenuUI.SetActive(false);
        CollisionDetection.GameOver = false;
        PerfectText.gameObject.SetActive(false);
        SceneManager.LoadScene("Main");
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
        PerfectText.gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        CollisionDetection.GameOver = false;
        PerfectText.gameObject.SetActive(false);
        SceneManager.LoadScene("LoadingScreen");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        PerfectText.gameObject.SetActive(false);
        Application.Quit();
    }
}