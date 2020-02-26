using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatUI : MonoBehaviour
{

    [SerializeField]
    private Text ui_textName;

    [SerializeField]
    private Image ui_image;

    [SerializeField]
    private GameObject check;

    private Hat hat;

    private void Start()
    {

    }

    public void Setup(Hat hat)
    {
        if (HatManager.isHatUnlocked(hat))
            ui_textName.text = hat.hatName;
        else
            ui_textName.text = "???";
        ui_image.sprite = hat.sprite;
        check.SetActive(HatManager.GetCurrentHat() == hat);
        this.hat = hat;
    }

    public void Press()
    {
        HatManager.EquipHat(hat);
    }

}