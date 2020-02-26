using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public static float GetCurrentDifficulty()
    {
        float f = Time.time - startTime + 1;
        return Mathf.Log(f, 3) + f / 300;
    }

    public static float GetCurrentTime()
    {
        return Time.time - startTime;
    }

    private static float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        //Debug.Log(GetCurrentDifficulty());
    }

}