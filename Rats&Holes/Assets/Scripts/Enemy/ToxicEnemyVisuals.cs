using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicEnemyVisuals : MonoBehaviour
{

    [SerializeField]
    private ToxicEnemy toxicEnemy;

    [SerializeField]
    private ParticleSystem explosionParticlesPrefab;

    [SerializeField]
    private AudioClip explosionAudio;

    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        toxicEnemy.OnExplode += ToxicEnemy_OnExplode;
    }

    private void OnDestroy()
    {
        toxicEnemy.OnExplode -= ToxicEnemy_OnExplode;
    }

    private void ToxicEnemy_OnExplode(object sender, System.EventArgs e)
    {
        audioSource.PlayOneShot(explosionAudio);
        Destroy(Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity), 2f);
    }
}