using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject mobileHud;

    public void Btn_EnableDeadeye()
    {
        player.EnableDeadeye(!player.isDeadeye);
    }

    private void Start()
    {
        mobileHud.gameObject.SetActive(UnityEngine.SystemInfo.deviceType == DeviceType.Handheld);
    }

}