using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        SceneManager.LoadScene("LoadingScreen");
    }
    public void LoadLevels()
        {
            Time.timeScale = 1f;
            ScoreSystem.score = 0;
            SceneManager.LoadScene("Menu");
        }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        ScoreSystem.score = 0;
        Application.Quit();
    }

}
