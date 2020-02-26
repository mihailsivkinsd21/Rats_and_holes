using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HolesSpawner : MonoBehaviour
{

    [SerializeField]
    private test test;

    [SerializeField]
    private Hole holePrefab;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    private float nextSpawnTime;

    private float time;

    private void Start()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        test.TrySpawnHole();
    }

    private void Update()
    {
        time = Time.time;
        if(Time.time >= nextSpawnTime)
        {
            SpawnHole();
        }
    }

    public void SpawnHole()
    {
        test.TrySpawnHole();

        float m = DifficultyManager.GetCurrentDifficulty();

        float min = minSpawnTime;
        float max = maxSpawnTime;
        if(minSpawnTime - m < 1)
        {
            minSpawnTime = 1;
        }
        else
        {
            min = minSpawnTime - m;
        }
        if (maxSpawnTime - m < 2)
        {
            maxSpawnTime = 2;
        }
        else
        {
            max = maxSpawnTime - m;
        }

        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

}