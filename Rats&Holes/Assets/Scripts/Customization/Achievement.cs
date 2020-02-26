using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{

    public string achievementName;
    [TextArea]
    public string achievementDescription;

    public Hat rewardHat;

    public Sprite image;

    [Header("Requirement")]
    public int ratskills;
    public int ratskillstotal;
    public int score;

}