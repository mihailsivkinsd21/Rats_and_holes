using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hole))]
[RequireComponent(typeof(AudioSource))]
public class HoleVisuals : MonoBehaviour
{

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Hole hole;


    private void Start()
    {
        hole.OnStageUpdated += Hole_OnStageUpdated;
    }
    private void OnDestroy()
    {
        hole.OnStageUpdated -= Hole_OnStageUpdated;
    }


    private void Hole_OnStageUpdated(object sender, System.EventArgs e)
    {
        float r = Random.Range(0.8f, 1.2f);
        audio.pitch = r;
        audio.PlayOneShot(audioClip);
    }
}