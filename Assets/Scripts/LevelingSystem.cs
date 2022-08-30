using System;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    private const int startingExpNeeded = 100;
    
    public static int GetCurrentLevel(int currentExp)
    {
        int i = 1;
        int lvlExp = startingExpNeeded;
        int setNewValue = User.Exp;
        
        while (currentExp >= lvlExp)
        {
            currentExp -= lvlExp;
            lvlExp += (int)Math.Floor(0.1*lvlExp);
            i++;
            setNewValue = currentExp;
        }

        User.Exp = setNewValue;
        User.Level = i;
        return i;
    }
    
    public static int GetExpNeeded(int level)
    {
        int lvlExp = startingExpNeeded;

        for (int j = 1; j < level; j++)
        {
            lvlExp += (int)Math.Floor(0.1*lvlExp);
        }
        
        return lvlExp;
    }
    
    // public static int GetCurrentLevelByTotalExp(long totalExp)
    // {
    //     int i = 1;
    //     int lvlExp = startingExpNeeded;
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
    //     int lvlExp = startingExpNeeded;
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