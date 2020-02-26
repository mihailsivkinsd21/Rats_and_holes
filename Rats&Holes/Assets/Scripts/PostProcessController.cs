using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessController : MonoBehaviour
{

    private const string simpleDeadeyeSaveName = "rats_simpleDeadeye";

    [SerializeField]
    private Volume volume;

    [SerializeField]
    private VolumeProfile defaultDeadeyeEffects;

    [SerializeField]
    private VolumeProfile simpleDeadeyeEffects;

    private bool isEnabled;

    public void Enable(bool b)
    {
        isEnabled = b;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(simpleDeadeyeSaveName) == 0)
        {
            volume.profile = defaultDeadeyeEffects;
        }
        else
        {
            volume.profile = simpleDeadeyeEffects;
        }
    }

    private void Update()
    {
        if(isEnabled)
        {
            if (volume.weight < 1)
                volume.weight = volume.weight + 0.1f;
            else
                volume.weight = 1;
        }
        else
        {
            if (volume.weight > 0)
                volume.weight = volume.weight - 0.1f;
            else
                volume.weight = 0;
        }
    }
}
