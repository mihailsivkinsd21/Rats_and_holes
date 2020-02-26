using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadeyeBar : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private Image deadeyeImage;

    [SerializeField]
    private Image deadeyeTreashold;

    private void Start()
    {
        deadeyeTreashold.fillAmount = player.deadeyeTreashold / 100;
    }

    private void Update()
    {
        deadeyeImage.fillAmount = player.deadeye / 100;
    }

}