using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    public static int score = 0;
    void Update()
    {
        scoreDisplay.SetText("Score: "+score);
    }
}
