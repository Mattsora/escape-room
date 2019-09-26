using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintController : MonoBehaviour
{
    public float timer = 60.0f;
    public Text hintOutput;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0f)
        {
            timerEnded();
        }
        else
        {
            timer -= Time.deltaTime;
        }
       
    }

    private void timerEnded()
    {
        hintOutput.text = "Tip";
        
    }
}
