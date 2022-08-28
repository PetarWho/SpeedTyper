using System;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class User : MonoBehaviour
{
    public static string Username { get; set; } = "Player" + Random.Range(0, 502003300);
    public static int Level { get; set; } = 1;
    public static int Exp { get; set; } = 0;
    public static int TotalExp { get; set; } = 0;
    public static Sprite Image { get; set; }
    public static int EasyWins { get; set; } = 0;
    public static int NormalWins { get; set; } = 0;
    public static int HardWins { get; set; } = 0;
    public static int InsaneWins { get; set; } = 0;
    public static int HighScore { get; set; } = 0;
    public static int Coins { get; set; } = 0;
    public static bool HasCompletedCampaign { get; set; } = false;
    public static int PerfectGames { get; set; } = 0;
    public static void IncreaseExp(int amount)
    {
        TotalExp += amount;
        Exp += amount;
    }
}


