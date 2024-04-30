using System;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    public static float wordFallSpeed;
    public float wordDelay;
    private float nextWordTime = 0f;
    public static long scoreToWin = long.MaxValue;
    public static int expGive = 0;

    private void Start()
    {
        if (int.TryParse(LevelLoader.staticDifficulty, out int level))
        {
            wordFallSpeed = 0.5f + (float)level / 75;
            wordDelay = 2f - (float)level / 175;
            Word.randomNumberStart = 1;
            Word.randomNumberEnd = 51 - (int)Math.Floor((double)level / 4);
            scoreToWin = (int)(50 + ((level - 1) / 99.0) * (1500 - 50));
            if (level < 100)
            {
                expGive = 0;
            }
            else
            {
                if (User.CampaignLevel == 99)
                {
                    expGive = 1000;
                }
                else
                {
                    expGive = 100;
                }
            }
        }

        else
        {
            switch (LevelLoader.staticDifficulty)
            {
                case "Easy":
                    wordFallSpeed = 1.2f;
                    wordDelay = 2f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 51;
                    scoreToWin = 3;
                    expGive = 105;
                    break;
                case "Normal":
                    wordFallSpeed = 1.4f;
                    wordDelay = 1.5f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 31;
                    scoreToWin = 500;
                    expGive = 20;
                    break;
                case "Hard":
                    wordFallSpeed = 1.65f;
                    wordDelay = 1.4f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 21;
                    scoreToWin = 1000;
                    expGive = 50;
                    break;
                case "Insane":
                    wordFallSpeed = 1.8f;
                    wordDelay = 1.25f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 11;
                    scoreToWin = 2000;
                    expGive = 150;
                    break;
                case "Endless":
                    wordFallSpeed = 1.3f;
                    wordDelay = 1.45f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 26;
                    expGive = 0;
                    scoreToWin = long.MaxValue;
                    break;
                case "Custom":
                    wordFallSpeed = GetCustomSettings.CustomSpeed;
                    wordDelay = GetCustomSettings.CustomDelay;
                    scoreToWin = GetCustomSettings.CustomScore;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = -1;
                    expGive = 0;
                    break;
            }
        }
    }

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
        }
    }
}