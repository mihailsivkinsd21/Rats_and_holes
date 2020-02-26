using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class HatManager 
{

    public delegate void HatUpdated(Hat newHat);

    public static event HatUpdated OnHatUpdated;

    private const string hatsPath = "rats_hat_";

    public static Hat GetCurrentHat()
    {
        if (PlayerPrefs.HasKey(hatsPath + "current"))
        {
            return GetHat(PlayerPrefs.GetString(hatsPath + "current"));
        }
        else
        {
            return GetDefaultHat();
        }
    }

    public static void EquipHat(Hat hat)
    {
        if (isHatUnlocked(hat))
        {
            PlayerPrefs.SetString(hatsPath + "current", hat.name);
            PlayerPrefs.Save();
            if (OnHatUpdated != null) OnHatUpdated(hat);
        }
    }

    public static Hat GetHat(string name)
    {
        return Resources.Load<Hat>("Hats/" + name);
    }


    public static List<Hat> GetMyHats()
    {
        List<Hat> hats = new List<Hat>();
        foreach (var item in GetHats())
        {
            if (isHatUnlocked(item))
            {
                hats.Add(item);
            }
        }
        hats.Add(GetDefaultHat());      
        return hats;
    }

    public static List<Hat> GetOtherHats()
    {
        List<Hat> hats = new List<Hat>();
        foreach (var item in GetHats())
        {
            if (!isHatUnlocked(item))
            {
                hats.Add(item);
            }
        }
        return hats;
    }

    public static List<Hat> GetHats()
    {
        List<Hat> hats = new List<Hat>();
        if (Resources.LoadAll<Hat>("Hats/").Length > 0)
        {
            foreach (var item in Resources.LoadAll<Hat>("Hats/"))
            {
                hats.Add(item);
            }
        }
        return hats;
    }

    public static bool isHatUnlocked(Hat hat)
    {
        if (hat == GetDefaultHat())
            return true;
        else
            return PlayerPrefs.GetInt(hatsPath + hat.name) == 1;
    }

    public static void UnlockHat(Hat hat)
    {
        PlayerPrefs.SetInt(hatsPath + hat.name, 1);
        PlayerPrefs.Save();
    }

    private static Hat GetDefaultHat()
    {
        return Resources.Load<Hat>("Hats/DefaultHat");
    }

}