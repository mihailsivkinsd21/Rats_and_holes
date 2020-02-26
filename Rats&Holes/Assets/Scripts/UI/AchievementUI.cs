using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{

    [SerializeField]
    private Text ui_textName;

    [SerializeField]
    private Text ui_textDesc;

    [SerializeField]
    private Image ui_image;

    [SerializeField]
    private GameObject check;

    public void Setup(Achievement achivement)
    {
        ui_textName.text = achivement.achievementName;
        ui_textDesc.text = achivement.achievementDescription;
        ui_image.sprite = achivement.image;
        check.SetActive(AchievementManager.isAchievementUnlocked(achivement));
    }

}