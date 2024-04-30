using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserProfile : MonoBehaviour
{
    [SerializeField] private Slider expBar;
    [SerializeField] private TextMeshProUGUI expNeededText;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI easyWins;
    [SerializeField] private TextMeshProUGUI normalWins;
    [SerializeField] private TextMeshProUGUI hardWins;
    [SerializeField] private TextMeshProUGUI insaneWins;
    [SerializeField] private TextMeshProUGUI campaignLevel;
    [SerializeField] private TextMeshProUGUI perfectGames;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        SaveSystem.Load();
    }
    
    void Start()
    {
        usernameText.text = User.Username;

        int level = LevelingSystem.GetCurrentLevel(User.TotalExp);
        currentLevelText.text = $"Level {level}";
        long expNeeded = LevelingSystem.GetExpNeeded(User.Level);
        expNeededText.text = $"{expNeeded - User.Exp} xp for next level";
        expBar.value = (float)(User.Exp) / (float)LevelingSystem.GetExpNeeded(User.Level);

        easyWins.text = $"Easy Wins: {User.EasyWins}";
        normalWins.text = $"Normal Wins: {User.NormalWins}";
        hardWins.text = $"Hard Wins: {User.HardWins}";
        insaneWins.text = $"INSANE Wins: {User.InsaneWins}";
        campaignLevel.text = "Campaign Level: " + (User.CampaignLevel > 100 ? "MAX" : User.CampaignLevel.ToString());
        perfectGames.text = $"Perfect Games: {User.PerfectGames}";
        coinText.text = User.Coins.ToString();
    }
}
