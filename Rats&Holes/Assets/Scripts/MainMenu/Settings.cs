using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    private const string globalVolumeSaveName = "rats_globalVolume";
    private const string musicVolumeSaveName = "rats_musicVolume";
    private const string effectsVolumeSaveName = "rats_effectsVolume";

    private const string simpleDeadeyeSaveName = "rats_simpleDeadeye";

    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private Slider ui_globalVolumeSlider;

    [SerializeField]
    private Slider ui_musicVolumeSlider;

    [SerializeField]
    private Slider ui_effectsVolumeSlider;

    [SerializeField]
    private Toggle ui_simpleDeadeyeToggle;

    public void SetGlobalVolume(float volume)
    {
        mixer.SetFloat("GlobalVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(globalVolumeSaveName, volume);
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(musicVolumeSaveName, volume);
    }

    public void SetEffectsVolume(float volume)
    {
        mixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(effectsVolumeSaveName, volume);
    }

    public void SetSimpleDeadeye(bool b)
    {
        if (b)
        {
            PlayerPrefs.SetInt(simpleDeadeyeSaveName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(simpleDeadeyeSaveName, 0);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(globalVolumeSaveName))
        {
            float f = PlayerPrefs.GetFloat(globalVolumeSaveName);
            SetGlobalVolume(f);
            ui_globalVolumeSlider.value = f;
        }
        else
        {
            ui_globalVolumeSlider.value = 1;
        }
        if (PlayerPrefs.HasKey(musicVolumeSaveName))
        {
            float f = PlayerPrefs.GetFloat(musicVolumeSaveName);
            SetMusicVolume(f);
            ui_musicVolumeSlider.value = f;
        }
        else
        {
            ui_musicVolumeSlider.value = 1;
        }
        if (PlayerPrefs.HasKey(effectsVolumeSaveName))
        {
            float f = PlayerPrefs.GetFloat(effectsVolumeSaveName);
            SetEffectsVolume(f);
            ui_effectsVolumeSlider.value = f;
        }
        else
        {
            ui_effectsVolumeSlider.value = 1;
        }
        if(PlayerPrefs.HasKey(simpleDeadeyeSaveName))
        {
            ui_simpleDeadeyeToggle.isOn = PlayerPrefs.GetInt(simpleDeadeyeSaveName) == 1;
        }
        else
        {
            ui_simpleDeadeyeToggle.isOn = false;
        }
    }

}