using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HoleStage
{

    public float stageTime;
    public float stageTimeMax;

    public Sprite sprite;

    public bool spawnEnemy;

    public bool generateEnemys;
    public float minRatTime;
    public float maxRatTime;

}