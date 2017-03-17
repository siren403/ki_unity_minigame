using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [System.Serializable]
    public struct FingerRange
    {
        public Transform mMin;
        public Transform mMax;
    }

    private SceneNiddleGame mScene = null;

    public List<FingerRange> mFingers = new List<FingerRange>();

    private bool mIsNiddleCollision = false;
    public bool IsNiddleCollision
    {
        get
        {
            return mIsNiddleCollision;
        }
    }

    public void SetSCene(SceneNiddleGame scene)
    {
        mScene = scene;
    }
    public bool CheckStab(Transform checkTransform)
    {
        Vector2 dir = Vector2.zero;
        float min = .0f;
        float max = .0f;

        float niddleRadian = .0f;
        dir = checkTransform.position - this.transform.position;
        niddleRadian = Mathf.Atan2(dir.y, dir.x);

        foreach (var range in mFingers)
        {
            dir = range.mMin.position - this.transform.position;
            min = Mathf.Atan2(dir.y, dir.x);
            dir = range.mMax.position - this.transform.position;
            max = Mathf.Atan2(dir.y, dir.x);

            if(niddleRadian >= min && niddleRadian <= max)
            {
                return true;
            }
        }
        return false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for(int i = 0;i<mFingers.Count;i++)
        {
            Gizmos.DrawLine(mFingers[i].mMin.transform.position, mFingers[i].mMax.transform.position);
            Gizmos.DrawLine(this.transform.position, mFingers[i].mMin.transform.position);
            Gizmos.DrawLine(this.transform.position, mFingers[i].mMax.transform.position);

        }
    }
#endif

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tagNiddle"))
        {
            mIsNiddleCollision = true;
            Debug.Log("ON");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("tagNiddle"))
        {
            mIsNiddleCollision = false;
        }
    }
}
