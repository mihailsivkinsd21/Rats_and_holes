
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{

    [SerializeField]
    private string newHightScoreText = "you achieved a new high score";

    [SerializeField]
    private string scoreText = "your score";

    [SerializeField]
    private string ratsKilledText = "rats killed";

    [SerializeField]
    private Game game;

    [SerializeField]
    private GameObject ui_gameoverScreen;

    [SerializeField]
    private Text ui_time;

    [SerializeField]
    private Text ui_ratsKilled;

    [SerializeField]
    private GameObject ui_achievementScreen;

    [SerializeField]
    private Transform ui_achievementsParent;

    [SerializeField]
    private AchievementUI achievementuiPrefab;

    private void Start()
    {
        AchievementManager.OnAchievementUnlocked += AchievementManager_OnAchievementUnlocked;
        game.OnGameEnded += Game_OnGameEnded;
        ui_gameoverScreen.SetActive(false);
        ui_achievementScreen.SetActive(false);
    }

    private void OnDestroy()
    {
        AchievementManager.OnAchievementUnlocked -= AchievementManager_OnAchievementUnlocked;
        game.OnGameEnded -= Game_OnGameEnded;
    }

    private void AchievementManager_OnAchievementUnlocked(Achievement achievement)
    {
        ui_achievementScreen.SetActive(true);
        Instantiate(achievementuiPrefab, ui_achievementsParent, false).Setup(achievement);
    }

    private void Game_OnGameEnded()
    {
        ui_gameoverScreen.SetActive(true);
        if (RecordsManager.GetRecord() < game.GetScore())
        {
            ui_time.text = newHightScoreText + ": " + (int)game.GetScore();
        }
        else
        {
            ui_time.text = scoreText + ": " + (int)game.GetScore();
        }
        ui_ratsKilled.text = ratsKilledText + ": " + game.GetPlayer().ratsKilled.ToString();
    }

}