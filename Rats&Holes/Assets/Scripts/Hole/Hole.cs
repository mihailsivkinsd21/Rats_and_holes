using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public event EventHandler OnStageUpdated;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private HoleStage[] holeStages;

    private int currentStage;

    private float nextStageTime;

    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private Enemy fastEnemy;

    [SerializeField]
    private Enemy toxicEnemy;

    private float nextRatTime;

    private void SetCurrentStage(int i)
    {
        if(i <= holeStages.Length - 1)
        {
            currentStage = i;
            sprite.sprite = holeStages[i].sprite;
            nextStageTime = Time.time + UnityEngine.Random.Range(holeStages[i].stageTime, holeStages[i].stageTimeMax);

            if (holeStages[i].spawnEnemy)
            {
                SpawnEnemy();
            }

            if(holeStages[i].generateEnemys)
            {
                GenerateEnemy();
            }
            if (OnStageUpdated != null) OnStageUpdated(this, EventArgs.Empty);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SetCurrentStage(0);
    }

    private void Update()
    {
        if (Time.time >= nextStageTime)
        {
            SetCurrentStage(currentStage + 1);
        }
        if(holeStages[currentStage].generateEnemys)
        {
            if(Time.time >= nextRatTime)
            {
                GenerateEnemy();
            }
        }
    }

    private void GenerateEnemy()
    {
        nextRatTime = UnityEngine.Random.Range(holeStages[currentStage].minRatTime, holeStages[currentStage].maxRatTime);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (DifficultyManager.GetCurrentTime() >= 60)
        {
            int i = UnityEngine.Random.Range(0, 51);
            if (i == 0)
            {
                SpawnToxicEnemy();
            }
            else
            {
                SpawnDefaultEnemy();
            }
        }
        else
        {
            SpawnDefaultEnemy();
        }
    }

    private void SpawnToxicEnemy()
    {
        Instantiate(toxicEnemy, transform.position, Quaternion.identity);
    }

    private void SpawnDefaultEnemy()
    {
        int i = UnityEngine.Random.Range(0, 101);
        if (i < 90 - DifficultyManager.GetCurrentDifficulty())
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(fastEnemy, transform.position, Quaternion.identity);
        }
    }

}