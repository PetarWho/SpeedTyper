using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private void Awake()
    {
        PauseMenu.GameIsPaused = false;
        Load();
    }

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;
    public static bool NewHighScore;

    public static int score = 0;
    public static int highScore = 0;
    void Update()
    {
        scoreDisplay.SetText("Score: "+score);
        if(NewHighScore)
            highScoreDisplay.SetText(("NEW High Score: " + highScore));
        else
        highScoreDisplay.SetText(("High Score: " + highScore));
    }

     static void Save()
    {
        PlayerPrefs.SetString("highScore", highScore.ToString());
        PlayerPrefs.SetString("coins", CoinScript.coins.ToString());
    }

     static void Load()
    {
        highScore = int.Parse(PlayerPrefs.GetString("highScore", "0"));
        CoinScript.coins = int.Parse(PlayerPrefs.GetString("coins", "0"));
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerPrefs.DeleteAll();
            Load();
        }
        else
        {
            Save();
        }
    }
}
