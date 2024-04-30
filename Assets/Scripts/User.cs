using UnityEngine;
using Random = UnityEngine.Random;

public class User : MonoBehaviour
{
    public static string Username { get; set; } = "Player" + Random.Range(100000000, 999999999);
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
    public static int CampaignLevel { get; set; } = 1;
    public static int PerfectGames { get; set; } = 0;
    public static void IncreaseExp(int amount)
    {
        TotalExp += amount;
        Exp += amount;
    }
}


