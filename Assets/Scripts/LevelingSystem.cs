using System;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    private const int baseExp = 100;

    public static int GetCurrentLevel(int currentExp)
    {
        int level = 1;
        int requiredExp = baseExp;

        while (currentExp >= requiredExp)
        {
            currentExp -= requiredExp;
            level++;
            requiredExp = GetExpNeeded(level);
        }

        User.Exp = currentExp;
        User.Level = level;

        return level;
    }

    public static int GetExpNeeded(int level)
    {
        int scalingFactor = 3;
        return (int)(baseExp + Math.Pow((User.Level * scalingFactor),1.5));
    }

    // public static int GetCurrentLevelByTotalExp(long totalExp)
    // {
    //     int i = 1;
    //     int lvlExp = baseExp;
    //     while (totalExp >= lvlExp)
    //     {
    //         lvlExp += (int)Math.Floor(0.1*lvlExp);
    //         i++;
    //     }
    //     User.Level = i;
    //     return i;
    // }

    // public static long GetTotalExpNeeded(int level)
    // {
    //     int lvlExp = baseExp;
    //     long total = lvlExp;
    //     
    //     for (int j = 1; j < level; j++)
    //     {
    //         lvlExp += (int)Math.Floor(0.1*lvlExp);
    //         total += lvlExp;
    //     }
    //     
    //     return total;
    // }
}