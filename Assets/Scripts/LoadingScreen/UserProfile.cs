using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserProfile : MonoBehaviour
{
    [SerializeField] private Slider expBar;
    [SerializeField] private TextMeshProUGUI expNeededText;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI usernameText;

    private void Awake()
    {
        SaveSystem.Load();
    }

    void Start()
    {
        int level = LevelingSystem.GetCurrentLevel(User.TotalExp);
        currentLevelText.text = $"Level {level}";
        long expNeeded = LevelingSystem.GetExpNeeded(User.Level);
        expNeededText.text = $"{expNeeded - User.Exp} xp for next level";
        usernameText.text = User.Username;
        expBar.value = (float)(User.Exp)/(float)LevelingSystem.GetExpNeeded(User.Level);
    }
}
