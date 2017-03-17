using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINiddleGame : MonoBehaviour
{
    private SceneNiddleGame mScene = null;

    public void SetScene(SceneNiddleGame scene)
    {
        mScene = scene;
    }

    public void OnClickOneMore()
    {
        mScene.OnOneMore();
    }

    public void OnClickGoTitle()
    {
        GameManager.GetInst().LoadScene(GameManager.SceneState.Title);
    }
}
