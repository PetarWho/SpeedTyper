using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static int coins;
    public TextMeshProUGUI coinDisplay;
    void Update()
    {
        coinDisplay.SetText(coins.ToString());
    }
}
