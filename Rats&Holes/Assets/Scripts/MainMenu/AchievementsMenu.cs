using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject achivementsParent;

    [SerializeField]
    private AchievementUI achievementUIPrefab;

    private void Start()
    {
        foreach (var item in AchievementManager.GetAchievements())
        {
            Instantiate(achievementUIPrefab, achivementsParent.transform, false).Setup(item);
        }
    }

}