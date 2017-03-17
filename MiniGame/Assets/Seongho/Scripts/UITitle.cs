using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitle : MonoBehaviour
{


    //public void OnClickStartGame(GameManager.SceneState state)
    //{
    //    GameManager.GetInst().LoadScene(state);
    //}

    public void OnClickStartCatGame()
    {
        GameManager.GetInst().LoadScene(GameManager.SceneState.CatGame);
    }
    public void OnClickStartPencilGame()
    {
        GameManager.GetInst().LoadScene(GameManager.SceneState.PencilGame);
    }
    public void OnClickStartNiddleGame()
    {
        GameManager.GetInst().LoadScene(GameManager.SceneState.NiddleGame);
    }
}
