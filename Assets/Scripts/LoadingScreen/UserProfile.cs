using System;
using System.Collections;
using System.Collections.Generic;
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
        int expNeeded = LevelingSystem.GetExpNeeded(User.Level);
        expNeededText.text = $"{expNeeded - User.Exp} xp til next level";
        usernameText.text = User.Username;
        expBar.value = LevelingSystem.ExpBarValue;
        Debug.Log("BAR VALUE " + LevelingSystem.ExpBarValue );
        Debug.Log(User.Exp + " exp");
        Debug.Log(User.Level + " level");
    }
}
