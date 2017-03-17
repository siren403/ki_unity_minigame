using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneTitle : MonoBehaviour
{
    public Text mTxtGold = null;
    public UITitle mUITitle = null;

    // Use this for initialization
    void Start()
    {
        mUITitle.SetScene(this);
        mTxtGold.text = string.Format("{0} GOLD", GameManager.GetInst().GetGold());
    }


    public void BuyItem()
    {
        if (GameManager.GetInst().UseGold(100))
        {
            Debug.Log("Buy Item");
            mTxtGold.text = string.Format("{0} GOLD", GameManager.GetInst().GetGold());
        }
    }
}
