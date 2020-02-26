using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    [SerializeField]
    private Game game;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] musics;

    private float nextMusicTime;

    private bool stop;

    private void Start()
    {
        game.OnGameEnded += Game_OnGameEnded;
    }

    private void OnDestroy()
    {
        game.OnGameEnded -= Game_OnGameEnded;
    }

    private void Game_OnGameEnded()
    {
        stop = true;
        audioSource.Stop();
    }

    private void Update()
    {
        if (stop)
        {
            return;
        }
        else if (Time.time >= nextMusicTime)
        {
            PlayRandomMusic();
        }
    }

    private void PlayRandomMusic()
    {
        audioSource.clip = musics[Random.Range(0, musics.Length)];
        nextMusicTime = Time.time + audioSource.clip.length;
        audioSource.Play();
    }

}