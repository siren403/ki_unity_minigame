using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour {

   // public CPenCil mpPenCilHead = null;

    public CScenePlayGame mpScene = null;
    


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

    public void OnClickPressTurn()
    {
        Debug.Log("Spin!");

        mpScene.OnPencilClose();
        //mpScene.mpPenCil.AddScore();
       // mpScene.mpPenCil.AddScore(10);
       
    }

    public void OnClickPressClose()
    {
        Debug.Log("Close!");

        mpScene.OnPencilPush();
       // mpScene.mpPenCil.AddScore();
        // mpScene.mpPenCil.AddScore(10);
    }
    public void OnClickPressExit()
    {
        //GameManager.GetInst().LoadScene(GameManager.SceneState.Title);
        mpScene.ShowPanel();
    }

    public void OnClickMainBack()
    {
        GameManager.GetInst().LoadScene(GameManager.SceneState.Title);
    }



}
