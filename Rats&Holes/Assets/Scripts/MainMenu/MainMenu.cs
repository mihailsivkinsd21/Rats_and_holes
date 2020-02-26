using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Text ui_hightScore;

    [SerializeField]
    private GameObject ui_mainScreen;

    [SerializeField]
    private GameObject ui_settingsScreen;

    [SerializeField]
    private GameObject ui_rewardsScreen;

    [SerializeField]
    private GameObject ui_cowboyScreen;

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        ui_mainScreen.SetActive(true);
        ui_settingsScreen.SetActive(false);
        ui_cowboyScreen.SetActive(false);
        ui_rewardsScreen.SetActive(false);
    }

    public void OpenSettings()
    {
        ui_mainScreen.SetActive(false);
        ui_settingsScreen.SetActive(true);
        ui_rewardsScreen.SetActive(false);
        ui_cowboyScreen.SetActive(false);
    }

    public void OpenRewards()
    {
        ui_mainScreen.SetActive(false);
        ui_settingsScreen.SetActive(false);
        ui_rewardsScreen.SetActive(true);
        ui_cowboyScreen.SetActive(false);
    }

    public void OpenCowboyScreen()
    {
        ui_mainScreen.SetActive(false);
        ui_settingsScreen.SetActive(false);
        ui_cowboyScreen.SetActive(true);
        ui_rewardsScreen.SetActive(false);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        OpenMainMenu();
        if (RecordsManager.HasRecord())
        {
            ui_hightScore.text = "Your high score is " + (int)RecordsManager.GetRecord();
        }
        else
        {
            ui_hightScore.gameObject.SetActive(false);
        }
    }

    private void Update()
    {

    }

}