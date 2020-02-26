using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementManager 
{

    public delegate void AchievementUnlocked(Achievement achievement);

    public static event AchievementUnlocked OnAchievementUnlocked;

    private const string acheivementsPath = "rats_achivement_";

    public static List<Achievement> GetMyAchievements()
    {
        List<Achievement> achivements = new List<Achievement>();
        foreach (var item in GetAchievements())
        {
            if(isAchievementUnlocked(item))
            {
                achivements.Add(item);
            }
        }
        return achivements;
    }

    public static List<Achievement> GetOtherAchievements()
    {
        List<Achievement> achivements = new List<Achievement>();
        foreach (var item in GetAchievements())
        {
            if (!isAchievementUnlocked(item))
            {
                achivements.Add(item);
            }
        }
        return achivements;
    }

    public static List<Achievement> GetAchievements()
    {
        List<Achievement> achivements = new List<Achievement>();
        if (Resources.LoadAll<Achievement>("Achievement/").Length > 0)
        {
            foreach (var item in Resources.LoadAll<Achievement>("Achievement/"))
            {
                achivements.Add(item);
            }
        }
        return achivements;
    }

    public static void TryUnlock()
    {
        foreach (var item in GetAchievements())
        {
            bool a = RecordsManager.GetRecord() >= item.score;
            bool b = RecordsManager.GetRatskills() >= item.ratskillstotal;
            bool c = RecordsManager.GetRecordKills() >= item.ratskills;
            if (a && b && c)
            {
                UnlockAcheivement(item);
            }
        }
    }

    private static void UnlockAcheivement(Achievement achievement)
    {
        if (!isAchievementUnlocked(achievement))
        {
            PlayerPrefs.SetInt(acheivementsPath + achievement.name, 1);
            if (OnAchievementUnlocked != null) OnAchievementUnlocked(achievement);
            if(achievement.rewardHat != null)
            {
                HatManager.UnlockHat(achievement.rewardHat);
            }
        }
    }

    public static bool isAchievementUnlocked(Achievement achievement)
    {
        return PlayerPrefs.GetInt(acheivementsPath + achievement.name) == 1;
    }

    public static void ResetAchievements()
    {
        List<Achievement> achivements = new List<Achievement>();
        foreach (var item in GetAchievements())
        {
            PlayerPrefs.SetInt(acheivementsPath + item.name, 0);
        }
    }

}