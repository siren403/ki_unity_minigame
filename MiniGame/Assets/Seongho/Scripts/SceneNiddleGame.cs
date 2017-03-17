using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneNiddleGame : MonoBehaviour
{
    public Hand mHand = null;
    public Niddle mNiddle = null;
    public UINiddleGame mUINiddleGame = null;

    [SerializeField]
    private Text mTxtStart = null;
    [SerializeField]
    private Text mTxtSafeCount = null;

    [SerializeField]
    private GameObject mPanelGameover = null;
    [SerializeField]
    private Text mTxtGoldCalculate = null;
    [SerializeField]
    private Text mTxtGoldReward = null;
    [SerializeField]
    private Button mBtnOneMore = null;
    [SerializeField]
    private Button mBtnGoTitle = null;


    private bool mIsPlaying = false;

    private int mSafeCount = 0;

    private void Awake()
    {
        mUINiddleGame.SetScene(this);
        mHand.SetSCene(this);
        mNiddle.SetScene(this);
    }

    private void Start()
    {
        StartCoroutine(SequenceStartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (mIsPlaying)
        {
            #region TouchInput
            //if(Input.touchCount > 0)
            //{
            //    if (Input.GetTouch(0).phase == TouchPhase.Began)
            //    {
            //        Debug.Log("Touch Began");

            //    }
            //}
            #endregion
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Touch Began");
                mNiddle.DoStab();
            }
        }
    }

    public void AddSafeCount()
    {
        mSafeCount++;
        mTxtSafeCount.text = mSafeCount.ToString();
    }
    private IEnumerator SequenceStartGame()
    {
        mNiddle.OnReset();
        mTxtSafeCount.text = "0";
        yield return new WaitForSeconds(1.0f);
        mTxtStart.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        mTxtStart.gameObject.SetActive(false);
        mNiddle.SetState(Niddle.STATE.Move);
        mIsPlaying = true;
    }
    private IEnumerator SequenceGameOver()
    {
        int baseGold = Random.Range(50, 150);
        int rewardGold = baseGold * mSafeCount;
        GameManager.GetInst().AddGold(rewardGold);
        yield return new WaitForSeconds(1.0f);
        mPanelGameover.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        mTxtGoldCalculate.text = string.Format("{0} GOLD X {1}", baseGold, mSafeCount);
        mTxtGoldCalculate.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        mTxtGoldReward.text = string.Format("{0} GOLD", rewardGold);
        mTxtGoldReward.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        mBtnGoTitle.gameObject.SetActive(true);
        mBtnOneMore.gameObject.SetActive(true);

    }

    public void OnGameOver()
    {
        mIsPlaying = false;
        StartCoroutine(SequenceGameOver());
    }

    public void OnOneMore()
    {
        mTxtGoldReward.gameObject.SetActive(false);
        mTxtGoldCalculate.gameObject.SetActive(false);
        mBtnGoTitle.gameObject.SetActive(false);
        mBtnOneMore.gameObject.SetActive(false);
        mPanelGameover.SetActive(false);
        StartCoroutine(SequenceStartGame());
    }
}
