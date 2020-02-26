using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class EnemyVisuals : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Enemy enemy;

    private void Start()
    {
        enemy.OnHealthChanged += Enemy_OnHealthChanged;
    }

    private void OnDestroy()
    {
        enemy.OnHealthChanged -= Enemy_OnHealthChanged;
    }

    private void Update()
    {
        if (enemy.isDead)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - Time.deltaTime * 1f);
        }
    }

    private void Enemy_OnHealthChanged(object sender, System.EventArgs e)
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        else
        {
            float r = Random.Range(0.8f, 1.2f);
            audioSource.pitch = r;
            audioSource.PlayOneShot(audioClip);
        }
        if(enemy.isDead)
        {
            animator.SetBool("IsDead", true);
            sprite.sortingOrder = 4;
        }
    }

}