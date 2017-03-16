using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNiddleGame : MonoBehaviour
{
    [SerializeField]
    private Niddle mNiddle = null;
   

    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        Debug.Log("Touch Began");

        //    }
        //}
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Touch Began");
            mNiddle.DoStab();
        }
    }
}
