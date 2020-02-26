using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatDrop : Drop
{

    [SerializeField]
    private Hat hat;

    public override void Take(Player player)
    {
        HatManager.UnlockHat(hat);
        HatManager.EquipHat(hat);
        base.Take(player);
    }

}