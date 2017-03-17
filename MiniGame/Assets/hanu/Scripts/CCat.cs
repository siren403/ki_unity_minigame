using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCat : CUnit {
    

    private CSceneCatPlayGame mpScene = null;

    protected bool mIsVisible = false;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void SetScene(CSceneCatPlayGame tpScene)
    {
        mpScene = tpScene;
    }

    virtual public void SetIsVisible(bool tIsVisible)
    {
        mIsVisible = tIsVisible;
    }
    virtual public bool GetIsVisible()
    {
        return mIsVisible;
    }
}
