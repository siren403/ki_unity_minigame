using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUI : MonoBehaviour {

    public CSceneCatPlayGame.CATTYPE mBoxType;
    private CSceneCatPlayGame mpScene = null;
  
   

  

    private Transform mCatDestination = null;
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

    public void OnClickBtnHeaven()
    {
        mBoxType = CSceneCatPlayGame.CATTYPE.HEAVEN;
        mCatDestination = mpScene.GetBox(mBoxType);
        InvokeRepeating("MovetoCat", 0.0f, 0.05f);
      
    }
    public void OnClickBtnMale()
    {
        Debug.Log("MaleBtn");
        mBoxType = CSceneCatPlayGame.CATTYPE.MALE;
        mCatDestination = mpScene.GetBox(mBoxType);
        InvokeRepeating("MovetoCat", 0.0f, 0.05f);

    }
    public void OnClickBtnFemale()
    {
        Debug.Log("FemaleBtn");
        mBoxType = CSceneCatPlayGame.CATTYPE.FEMALE;
        mCatDestination = mpScene.GetBox(mBoxType);
        InvokeRepeating("MovetoCat", 0.0f, 0.05f);
    }



    public void MovetoCat()
    {
        CCat tCat = null;

        tCat = mpScene.GetCurrentCat();

        tCat.transform.position = Vector3.MoveTowards(tCat.transform.position, mCatDestination.position, 0.5f);
        
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

    public void OnClickGotitle()
    {
        GameManager.GetInst().AddGold(CHanMgr.GetInstance().GetCount() * 10);
        GameManager.GetInst().LoadScene(GameManager.SceneState.Title);
        CHanMgr.GetInstance().ReSetCount();

    }

    public void OnClickReturn()
    {
        mpScene.SetReSultVisible(false);
    }

    public void OnClickExitBtn()
    {
        mpScene.mTxtGold.text = "GOLD: " + (CHanMgr.GetInstance().GetCount()*10).ToString();
        mpScene.SetReSultVisible(true);
        
    }

}
