using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class User
{
    public string Username { get; set; } = "Player " + Random.Range(0, 502003300);
    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 0;
    public Image Image { get; set; }
    public int EasyWins { get; set; } = 0;
    public int NormalWins { get; set; } = 0;
    public int HardWins { get; set; } = 0;
    public int InsaneWins { get; set; } = 0;
    public bool HasCompletedCampaign { get; set; } = false;
}
