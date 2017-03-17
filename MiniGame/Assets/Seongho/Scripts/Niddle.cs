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

    private SceneNiddleGame mScene = null;

    [SerializeField]
    private STATE mState = STATE.Ready;
    [SerializeField]
    private float mDistance = 0.0f;
    [SerializeField]
    private Sprite mSpriteNonePick = null;
    [SerializeField]
    private Sprite mSpritePick = null;

    private Animator mAnimNiddle = null;
    private SpriteRenderer mSpriterNiddle = null;

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
    void Awake()
    {
        mAnimNiddle = GetComponentInChildren<Animator>();
        mSpriterNiddle = GetComponentInChildren<SpriteRenderer>();
        SetNiddlePosition(0);
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
                SetNiddlePosition(mCurrentTime);
                break;
        }
    }

    private void SetNiddlePosition(float time)
    {
        Vector3 pos = mScene.mHand.transform.position;
        pos.x += Mathf.Cos(Mathf.PingPong(time, Mathf.PI)) * mDistance;
        pos.y += Mathf.Sin(Mathf.PingPong(time, Mathf.PI)) * mDistance;
        this.transform.position = pos;
    }

    public void SetScene(SceneNiddleGame scene)
    {
        mScene = scene;
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
        if(mScene.mHand.IsNiddleCollision)
        {
            //mSpriterNiddle.sprite = mSpritePick;
            mAnimNiddle.SetTrigger("TrigAniStop");
            mState = STATE.Ready;
            mScene.OnGameOver();
        }
        else
        {
            mScene.AddSafeCount();
        }
    }

    public void SetState(STATE state)
    {
        mState = state;
    }
    public void OnReset()
    {
        mCurrentTime = 0;
        mIsStabbing = false;
        mAnimNiddle.SetTrigger("TrigAniReady");
        SetNiddlePosition(0);
    }
}
