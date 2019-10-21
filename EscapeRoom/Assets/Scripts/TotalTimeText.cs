using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalTimeText : MonoBehaviour
{
    GameTracker mTracker;
    Text mText;
    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponent<Text>();
        mTracker = FindObjectOfType<GameTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = "Your total time is : " + mTracker.m_minutes + " : " + mTracker.m_seconds;
    }
}
