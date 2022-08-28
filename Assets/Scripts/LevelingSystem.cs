using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    private const int startingExpNeeded = 100;
    public static float ExpBarValue = float.Parse(User.Exp.ToString()) / float.Parse(GetExpNeeded(User.Level).ToString());
    
    public static int GetCurrentLevel(int currentExp)
    {
        int i = 1;
        int lvlExp = startingExpNeeded;
        while (currentExp >= lvlExp)
        {
            lvlExp += (int)Math.Floor(0.1*lvlExp);
            i++;
        }

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

    private static long GetTotalExpNeeded(int level)
    {
        int lvlExp = startingExpNeeded;
        long total = lvlExp;
        
        for (int j = 1; j < level; j++)
        {
            lvlExp += (int)Math.Floor(0.1*lvlExp);
            total += lvlExp;
        }
        
        Debug.Log("Float total Exp " + (float)total);
        
        return total;
    }
}