using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class GetCustomSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField _customSpeed;
    [SerializeField] private TMP_InputField _customDelay;
    [SerializeField] private TMP_InputField _customScore;
    
    public static float CustomSpeed;
    public static float CustomDelay;
    public static int CustomScore;

    public void StartTheGame()
    {
        
        float cs = float.Parse(_customSpeed.text.ToString());
        float cd = float.Parse(_customDelay.text.ToString());
        int csc = int.Parse(_customScore.text.ToString());

        // if (cs > 20) cs = 20f;
        //
        // if (cd * 50 <= cs)
        // {
        //     CustomDelay = cd;
        // }
        // else
        // {
        //     CustomDelay = cs / 50;
        // }
        CustomDelay = cd;
        CustomSpeed = cs;
        CustomScore = csc;
    }
}
