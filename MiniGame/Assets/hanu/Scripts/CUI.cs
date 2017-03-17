using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUI : MonoBehaviour {

    public CScenePlayGame.CATTYPE mBoxType;
    private CScenePlayGame mpScene = null;
  
   

  

    private Transform mCatDestination = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScene(CScenePlayGame tpScene)
    {
        mpScene = tpScene;
    }

    public void OnClickBtnHeaven()
    {
        mBoxType = CScenePlayGame.CATTYPE.HEAVEN;
        mCatDestination = mpScene.GetBox(mBoxType);
        InvokeRepeating("MovetoCat", 0.0f, 0.05f);
      
    }
    public void OnClickBtnMale()
    {
        Debug.Log("MaleBtn");
        mBoxType = CScenePlayGame.CATTYPE.MALE;
        mCatDestination = mpScene.GetBox(mBoxType);
        InvokeRepeating("MovetoCat", 0.0f, 0.05f);

    }
    public void OnClickBtnFemale()
    {
        Debug.Log("FemaleBtn");
        mBoxType = CScenePlayGame.CATTYPE.FEMALE;
        mCatDestination = mpScene.GetBox(mBoxType);
        InvokeRepeating("MovetoCat", 0.0f, 0.05f);
    }

    public void MovetoCat()
    {
        CCat tCat = null;

        tCat = mpScene.GetCurrentCat();

        tCat.transform.position = Vector3.MoveTowards(tCat.transform.position, mCatDestination.position, 0.1f);
        
        if(0.1f > Vector3.Distance(tCat.transform.position,mCatDestination.position))
        {
            CancelInvoke("MovetoCat");
            mpScene.GetCurrentCat().SetIsVisible(false);
            mpScene.CompareBoxtoCat(mBoxType);
            mpScene.Appear();
            
        }


        /*
        float tSpeed = 10.0f;

        
        if (3 <= mpScene.GetCurrentCat().transform.position.x)
        {
            CancelInvoke("MovetoCat");
            mpScene.GetCurrentCat().SetIsVisible(false);
            mpScene.GetCurrentCat().transform.position = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        else
        {
            mpScene.GetCurrentCat().transform.Translate(new Vector3(tSpeed * Time.deltaTime,0, 0));
        }
        */
    }

}
