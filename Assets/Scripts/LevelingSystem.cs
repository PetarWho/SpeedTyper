using System;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    private const int baseExp = 100;

    public static int GetCurrentLevel(int totalExp)
    {
        int level = 1;
        int requiredExp = GetExpNeeded(level);
    
        while (totalExp >= requiredExp)
        {
            totalExp -= requiredExp;
            level++;
            requiredExp = GetExpNeeded(level);
        }

        User.Exp = totalExp;
        User.Level = level;
        SaveSystem.Save();
        return level;
    }

    public static int GetExpNeeded(int level)
    {
        int scalingFactor = 3;
        return (int)(baseExp + Math.Pow((level * scalingFactor),1.5));
    }
}