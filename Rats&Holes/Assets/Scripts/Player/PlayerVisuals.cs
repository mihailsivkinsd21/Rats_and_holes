using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(AudioSource))]
public class PlayerVisuals : MonoBehaviour
{

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private AudioClip damage;

    [SerializeField]
    private AudioClip heal;

    [SerializeField]
    private AudioClip shoot;

    [SerializeField]
    private AudioClip deadeye;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Transform shootStartPosition;

    [SerializeField]
    private ShootVisual linePrefab;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private Cowboy cowboy;

    [SerializeField]
    private PostProcessController postProcessController;

    [SerializeField]
    private AudioManager audioManager;

    private void Start()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
        player.OnPlayerShooted += Player_OnPlayerShooted;
        player.OnDeadeyeStart += Player_OnDeadeyeStart;
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= Player_OnHealthChanged;
        player.OnPlayerShooted -= Player_OnPlayerShooted;
        player.OnDeadeyeStart -= Player_OnDeadeyeStart;
    }

    private void Player_OnDeadeyeStart(bool started)
    {
        postProcessController.Enable(started);
        audioManager.StartDeadeye(started);
        if (started)
        {
            PlayAudio(deadeye, 0.9f, 1.1f, 1f);
        }
    }

    private void Player_OnHealthChanged(bool isBad, int health)
    {
        if(isBad)
        {
            PlayAudio(damage, 0.8f, 1.2f, 0.4f);
        }
        else
        {
            PlayAudio(heal, 0.8f, 1.2f, 0.4f);
        }
        if(health <= 0)
        {

            PlayAudio(deathSound, 1, 1, 0.4f);
        }
    }

    private void Player_OnPlayerShooted(RaycastHit2D hit)
    {
        PlayAudio(shoot, 0.8f, 1.2f, 0.3f);     
        cowboy.Shoot();
        Destroy(Instantiate(hitEffect, hit.point, Quaternion.identity), 1f);
    }

    private void PlayAudio(AudioClip clip, float minPitch, float maxPitch, float volume)
    {
        float r = Random.Range(minPitch, maxPitch);
        audio.volume = volume;
        audio.pitch = r;
        audio.PlayOneShot(clip);
    }

}