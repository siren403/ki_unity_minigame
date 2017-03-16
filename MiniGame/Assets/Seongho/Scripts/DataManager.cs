using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private static DataManager mInstance = null;

    public static DataManager GetInst()
    {
        if(mInstance == null)
        {
            mInstance = new DataManager();
        }
        return mInstance;
    }

    private PlayerPrefsInt mGold = new PlayerPrefsInt("gold");

    public void AddGold(int gold)
    {
        int savedGold = mGold.Value;
        savedGold += gold;
        mGold.Value = savedGold;
    }
    public int GetGold()
    {
        return mGold.Value;
    }
}
