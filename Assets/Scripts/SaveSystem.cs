using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void Save()
    {
        PlayerPrefs.SetString("highScore", User.HighScore.ToString());
        PlayerPrefs.SetString("coins", User.Coins.ToString());
        PlayerPrefs.SetString("userExp", User.Exp.ToString());
        PlayerPrefs.SetString("userTotalExp", User.TotalExp.ToString());
        PlayerPrefs.SetString("userLevel", User.Level.ToString());
        PlayerPrefs.SetString("userEasyWins", User.EasyWins.ToString());
        PlayerPrefs.SetString("userNormalWins", User.NormalWins.ToString());
        PlayerPrefs.SetString("userHardWins", User.HardWins.ToString());
        PlayerPrefs.SetString("userInsaneWins", User.InsaneWins.ToString());
        PlayerPrefs.SetString("userUsername", User.Username);
        PlayerPrefs.SetString("userPerfectGames", User.PerfectGames.ToString());
        PlayerPrefs.SetString("userCampaignLevel", User.CampaignLevel.ToString());
    }

    public static void Load()
    {
        User.HighScore = int.Parse(PlayerPrefs.GetString("highScore", "0"));
        User.Coins = int.Parse(PlayerPrefs.GetString("coins", "0"));
        User.Exp = int.Parse(PlayerPrefs.GetString("userExp", "0"));
        User.TotalExp = int.Parse(PlayerPrefs.GetString("userTotalExp", "0"));
        User.Level = int.Parse(PlayerPrefs.GetString("userLevel", "1"));
        User.EasyWins = int.Parse(PlayerPrefs.GetString("userEasyWins", "0"));
        User.NormalWins = int.Parse(PlayerPrefs.GetString("userNormalWins", "0"));
        User.HardWins = int.Parse(PlayerPrefs.GetString("userHardWins", "0"));
        User.InsaneWins = int.Parse(PlayerPrefs.GetString("userInsaneWins", "0"));
        User.Username = PlayerPrefs.GetString("userUsername", User.Username);
        User.PerfectGames = int.Parse(PlayerPrefs.GetString("userPerfectGames", "0"));
        User.CampaignLevel = int.Parse(PlayerPrefs.GetString("userCampaignLevel", "1"));
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
