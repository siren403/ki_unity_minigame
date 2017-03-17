using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneTitle : MonoBehaviour
{
    public Text mTxtGold = null;


    // Use this for initialization
    void Start()
    {
        mTxtGold.text = string.Format("{0} GOLD", GameManager.GetInst().GetGold());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
