using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<TextMeshProUGUI> highScoreDisplays = new List<TextMeshProUGUI>();
    public static bool NewHighScore;
    
    public static Dictionary<string, int> WinTrophies = new Dictionary<string, int>();

    public static int score = 0;
    public static int highScore = 0;
    void Update()
    {
        scoreDisplay.SetText("Score: "+score);
        if(NewHighScore)
            highScoreDisplays.ForEach(x=>x.SetText(("NEW High Score: " + highScore)));
        else
            highScoreDisplays.ForEach(x=>x.SetText(("High Score: " + highScore)));
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
