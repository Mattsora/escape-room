using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    public GameTracker tracker;
    public float m_minutes, m_seconds;
    public float combinedTime;
    private void Awake()
    {
        
        if(tracker != null && tracker != this)
        {
            Destroy(this.gameObject);
            return;
        }
        tracker = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
