using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject hearthPrefab;

    private void Start()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
        UpdateHealthBar();
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(bool isBad, int health)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < player.health; i++)
        {
            Instantiate(hearthPrefab, this.transform, false);
        }
    }

}