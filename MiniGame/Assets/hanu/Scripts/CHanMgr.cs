using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHanMgr
{
    private static CHanMgr mpInstance = null;

    public int mConut;

    private CHanMgr()
    {
        mpInstance = null;
    }

    public static CHanMgr GetInstance()
    {
        if(null == mpInstance)
        {
            mpInstance = new CHanMgr();
        }
        return mpInstance;
    }

    public void AddCount()
    {
        mConut += 1;
    }

    public int GetCount()
    {
        return mConut;
    }
}
