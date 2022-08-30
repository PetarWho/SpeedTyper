using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private void Awake()
    {
        PauseMenu.GameIsPaused = false;
        SaveSystem.Load();
    }

    public TextMeshProUGUI scoreDisplay;
    public List<TextMeshProUGUI> highScoreDisplays = new List<TextMeshProUGUI>();
    public static bool NewHighScore;

    public static int score = 0;
    void Update()
    {
        scoreDisplay.SetText("Score: "+score);
        if(NewHighScore)
            highScoreDisplays.ForEach(x=>x.SetText(("NEW High Score: " + User.HighScore)));
        else
            highScoreDisplays.ForEach(x=>x.SetText(("Highest Score: " + User.HighScore)));
    }

     
}
