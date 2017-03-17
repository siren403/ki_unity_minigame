using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager mInstance = null;
    public static GameManager GetInst()
    {
        if(mInstance == null)
        {
            mInstance = new GameManager();
        }
        return mInstance;
    }
    public enum SceneState
    {
        Title = 0,
        CatGame = 1,
        PencilGame = 2,
        NiddleGame = 3,
    }

    private PlayerPrefsInt mGold = null;
    private Dictionary<SceneState, string> mSceneNames = null;

    private GameManager()
    {
        mGold = new PlayerPrefsInt("gold");
        mSceneNames = new Dictionary<SceneState, string>();
        mSceneNames.Add(SceneState.Title, "SceneTitle");
        mSceneNames.Add(SceneState.PencilGame, "PenCilGame");
        mSceneNames.Add(SceneState.CatGame, "Cat");
        mSceneNames.Add(SceneState.NiddleGame, "SceneNiddleGame");

    }

    public void AddGold(int gold)
    {
        int savedGold = mGold.Value;
        savedGold += gold;
        mGold.Value = savedGold;
    }
    public int GetGold()
    {
        return mGold.Value;
    }

    public void LoadScene(SceneState scene)
    {
        string sceneName = string.Empty;
        if (mSceneNames.TryGetValue(scene, out sceneName))
        {
            if(string.IsNullOrEmpty(sceneName) == false)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("scene name is empty");
            }
        }
        else
        {
            Debug.LogError("not find scenestate");
        }
    }
}
