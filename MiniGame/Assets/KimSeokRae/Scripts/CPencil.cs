using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CPencil : MonoBehaviour {
    public CScenePlayGame mpScene = null;


    //public CPencil mpHead = null;
    //public CPencil mpBody = null;

    public bool mIsClose;
    public bool mIsTurn;


   // public CPencil PFPencil = null;
    public Transform mpHead = null;
    public Transform mpBody = null;

    public bool mIsMove = false;

    //public Text scoreText=null;
    //public int Score = 0;
   // public GameObject mpHead = null;
   

    // public Transform TrHead = null;
    // Use this for initialization
    void Start () {

        // this.mpBody.rotation = Quaternion.Euler(180, 0, 0);
        RandomStart();
	}
	
	// Update is called once per frame
	void Update () {
		if(mIsMove==true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(-3, 0, 0), 0.1f);

            if (Vector3.Distance(this.transform.position, new Vector3(-3, 0, 0))<=0.1f)
            {
                gameObject.SetActive(false);
                mIsMove = false;

                RandomStart();
            }
        }
	}
    

    void RandomStart()
    {
        OnPush(false, false);


        OnTurn(Random.Range(0, 11) <= 5 ? true : false);

    }
    /*
    public void Zhead()
    {
        mpHead.transform.position = (new Vector3(1.8f, 3.5f, -1));
    }
    */
    public bool OnPush(bool tA,bool IsCompare=true)
    {
        if (IsCompare==true&&mIsClose == true&&mIsTurn==true)
        {
            Debug.Log("dsaldksaldksasa");




            mIsMove = true;

            // Score += num;
            //scoreText.text = "Money :" + Score;
            return true;
        }

        mIsClose = tA;
        if(mIsClose)
        {
            mpHead.localPosition = (new Vector3(0, 2, 0));
            //mpHead.Translate(new Vector3(0, -1.5f, 0));
        }
        else
        {
            mpHead.localPosition = (new Vector3(0, 3.5f, 0));
            //mpHead.Translate(new Vector3(0, 1.5f, 0));
        }

        return false;
    }
    public void OnTurn(bool tB)
    {
        if(mIsClose==true)
        {
            return;
        }
        mIsTurn = tB;
        if (mIsTurn)
        {
            mpBody.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            mpBody.rotation = Quaternion.Euler(180, 0, 0);
        }

    }

    public void SetScene(CScenePlayGame tpScene)
    {
        mpScene = tpScene;
    }
    /*
    public void AddScore()
    {
        if (mIsClose == mIsTurn)
        {
            Debug.Log("dsaldksaldksasa");

            mpBody.position = (new Vector3(-2, 0, 0));
            mpHead.position = (new Vector3(-2, 0, 0));

            // Score += num;
            //scoreText.text = "Money :" + Score;
        }
     }
     */
     /*
     public void MovePencil()
    {
        if (mIsClose == mIsTurn)
        {
            Debug.Log("dsaldksaldksasa");

            mpBody.position = (new Vector3(-2, 0, 0));
            mpHead.position = (new Vector3(-2, 0, 0));

            // Score += num;
            //scoreText.text = "Money :" + Score;
        }
    }
    */
}
