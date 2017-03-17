using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CScenePlayGame : MonoBehaviour {

    public CPencil PFPenCil = null;
    //public CPencil mpPenCil = null;


    public List<CPencil> mPencils = null;
    public int mPencilnum = 0;

    public CUIPlayGame mpUi = null;
    public int mPencilMoney = 0;
    public Text mTxtMoney = null;
	// Use this for initialization
	void Start () {


        /*
        Debug.Log("GameStart!!");
        //볼펜몸체 생성
         mpPenCil = Instantiate<CPencil>(PFPenCil,new Vector3(0, 0, 0), Quaternion.identity);
         //mpPenCil.Zhead();
         mpPenCil.SetScene(this);
         */
        Appear();
	}
	
    public void Appear()
    {
        mPencils[mPencilnum].transform.position = new Vector3(0, 0, 0);
        mPencils[mPencilnum].gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
    }

    public void OnPencilPush()
    {
        if(mPencils[mPencilnum].OnPush(!mPencils[mPencilnum].mIsClose))
        {
            mPencilnum++;
            if(mPencils.Count<=mPencilnum)
            {
                mPencilnum = 0;
            }
            Appear();
            mPencilMoney++;
            mTxtMoney.text = string.Format("Money : {0}", mPencilMoney);
        }

    }


    public void OnPencilClose()
    {
        mPencils[mPencilnum].OnTurn(!mPencils[mPencilnum].mIsTurn);
    }

}
