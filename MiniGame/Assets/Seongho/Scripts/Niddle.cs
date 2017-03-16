using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niddle : MonoBehaviour
{
    public enum STATE
    {
        Ready = 0,
        Move = 1,
    }

    [SerializeField]
    private Hand mHand = null;

    [SerializeField]
    private STATE mState = STATE.Ready;
    [SerializeField]
    private float mDistance = 0.0f;

    private Animator mAnimNiddle = null;

    private float mCurrentTime = 0;

    private bool mIsStabbing = false;
    public bool IsStabbing
    {
        set
        {
            mIsStabbing = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        mAnimNiddle = GetComponentInChildren<Animator>();
        Vector3 pos = mHand.transform.position;
        pos.x += Mathf.Cos(0) * mDistance;
        pos.y += Mathf.Sin(0) * mDistance;
        this.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        switch(mState)
        {
            case STATE.Ready:
                break;
            case STATE.Move:
                mCurrentTime += Time.deltaTime * 0.7f;
                Vector3 pos = mHand.transform.position;
                pos.x += Mathf.Cos(Mathf.PingPong(mCurrentTime, Mathf.PI)) * mDistance;
                pos.y += Mathf.Sin(Mathf.PingPong(mCurrentTime, Mathf.PI)) * mDistance;
                this.transform.position = pos;
                break;
        }

    }

    public void DoStab()
    {
        if(mIsStabbing == false)
        {
            mIsStabbing = true;
            mAnimNiddle.SetTrigger("TrigAniOnStab");
        }
    }

    public void OnInStabComplete()
    {
        //if(mHand.CheckStab(mAnimNiddle.transform))
        if(mHand.IsNiddleCollision)
        {
            mAnimNiddle.Stop();
            mState = STATE.Ready;
        }
    }
}
