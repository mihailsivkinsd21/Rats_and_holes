using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecordsManager 
{

    private const string record = "rats_record";
    private const string recordKills = "rats_killsRecord";
    private const string ratkills = "rats_kills";

    public static float GetRecord()
    {
        return PlayerPrefs.GetFloat(record);
    }

    public static void SetRecord(float newRecord)
    {
        if (newRecord > PlayerPrefs.GetFloat(record))
        {
            PlayerPrefs.SetFloat(record, newRecord);
            PlayerPrefs.Save();
        }
    }

    public static bool HasRecord()
    {
        return PlayerPrefs.HasKey(record);
    }

    public static float GetRecordKills()
    {
        return PlayerPrefs.GetFloat(recordKills);
    }

    public static void SetRecordKills(float newRecord)
    {
        if (newRecord > GetRecordKills())
        {
            PlayerPrefs.SetFloat(recordKills, newRecord);
            PlayerPrefs.Save();
        }
    }

    public static float GetRatskills()
    {
        return PlayerPrefs.GetFloat(ratkills);
    }

    public static void AddRatskills(float kills)
    {
        float f = GetRatskills();
        PlayerPrefs.SetFloat(ratkills, f + kills);
    }

}