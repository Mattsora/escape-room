using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public bool timerStop;
    bool alreadySent;
    public TextMeshPro timerText;
    private float startTime;
    GameTracker tracker;
    float m_minutes, m_seconds;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        tracker = FindObjectOfType<GameTracker>();
    }
    public void SendTimeToTracker()
    {
        tracker.m_minutes += m_minutes;
        tracker.m_seconds += m_seconds;
        alreadySent = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(timerStop)
        {
            startTime = Time.time;
            timerText.text = "";
        }
        if (!timerStop)
        {
            float t = Time.time - startTime;
           
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            m_minutes = float.Parse(minutes);
            m_seconds = float.Parse(seconds);
            timerText.text = minutes + ":" + seconds;
        }
    }
}
