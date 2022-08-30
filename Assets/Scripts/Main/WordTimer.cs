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
            if (level > 0 && level <= 100)
            {
                wordFallSpeed = 0.5f + (float) level / 75;
                wordDelay = 2f - (float) level / 175;
                Word.randomNumberStart = 1;
                Word.randomNumberEnd = 51 - (int) Math.Floor((double) level / 4);
                scoreToWin = 5 * (level + 3);
                if (level < 50)
                {
                    expGive = 0;
                }
                else
                {
                    expGive = level - 40;
                }
            }
            else
            {
                wordFallSpeed = 1f;
                wordDelay = 100f;
                Word.randomNumberStart = 1;
                Word.randomNumberEnd = -1;
                scoreToWin = 1;
                expGive = 0;
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
                    scoreToWin = 200;
                    expGive = 10;
                    break;
                case "Normal":
                    wordFallSpeed = 1.4f;
                    wordDelay = 1.5f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 31;
                    scoreToWin = 300;
                    expGive = 20;
                    break;
                case "Hard":
                    wordFallSpeed = 1.65f;
                    wordDelay = 1.4f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 23;
                    scoreToWin = 400;
                    expGive = 40;
                    break;
                case "Insane":
                    wordFallSpeed = 1.8f;
                    wordDelay = 1.3f;
                    Word.randomNumberStart = 1;
                    Word.randomNumberEnd = 16;
                    scoreToWin = 500;
                    expGive = 80;
                    break;
                case "Endless":
                    wordFallSpeed = 1.25f;
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