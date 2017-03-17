using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFemalecat : CCat {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SetIsVisible(bool tIsVisible)
    {
        mIsVisible = tIsVisible;
        this.gameObject.SetActive(tIsVisible);
    }
    public override bool GetIsVisible()
    {
        return mIsVisible;
    }
}
