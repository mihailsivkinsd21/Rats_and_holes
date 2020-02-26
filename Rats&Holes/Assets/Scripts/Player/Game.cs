using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public const string path = "rats_dontShowHelp";

    public delegate void GameEnded();

    public event GameEnded OnGameEnded;

    public bool isPaused { get; private set; }

    [SerializeField]
    public Player player;

    [SerializeField]
    private GameObject ui_pause;

    [SerializeField]
    private GameObject ui_help;

    [SerializeField]
    private Text ui_time;

    private float score;

    public Player GetPlayer()
    {
        return player;
    }

    public float GetScore()
    {
        return score;
    }

    private void SetPause(bool b)
    {
        player.enabled = !b;
        if (b)
        {
            player.EnableDeadeye(false);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ShowPause(bool b)
    {
        ShowHelp(false);
        isPaused = b;
        SetPause(b);
        ui_pause.SetActive(b);
    }

    public void ShowHelp(bool b)
    {
        SetPause(b);
        ui_help.SetActive(b);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
        if(PlayerPrefs.GetInt(path) == 0)
        {
            ShowHelp(true);
            PlayerPrefs.SetInt(path, 1);
        }
    }

    private void Update()
    {
        score += Time.deltaTime;
        ui_time.text = "Score: " + (int)score;
        if (player.health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowPause(!isPaused);
            }
        }
    }
    private void GameOver()
    {
        SetPause(false);

        player.EnableDeadeye(false);
        player.enabled = false;
        Time.timeScale = 0;

        //Save new record 
        RecordsManager.SetRecord(score);
        RecordsManager.SetRecordKills(player.ratsKilled);
        RecordsManager.AddRatskills(player.ratsKilled);

        AchievementManager.TryUnlock();

        if (OnGameEnded != null) OnGameEnded();
    }

    private void Player_OnHealthChanged(bool isBad, int health)
    {
        if(health <= 0)
        {
            SetPause(false);
            GameOver();
        }
    }

}