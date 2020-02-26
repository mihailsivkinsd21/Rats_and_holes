using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private Effect[] deadeyeEffects;

    public void StartDeadeye(bool b)
    {
        if (deadeyeEffects.Length <= 0)
            return;
        foreach (var item in deadeyeEffects)
        {
            if (b)
                mixer.SetFloat(item.name, item.deadeyeValue);
            else
                mixer.SetFloat(item.name, item.defaultValue);
        }
    }

    private void Start()
    {
        StartDeadeye(false);
    }

}

[System.Serializable]
public class Effect
{

    public string name;
    public float defaultValue;
    public float deadeyeValue;

}