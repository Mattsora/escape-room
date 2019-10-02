using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintController : MonoBehaviour
{
    public bool Enabled = true;

    public float TimeUntilHint = 60.0f;
    public float timer;

    public Text hintOutput;
    public List<string> Message = new List<string>();
    internal int currentMessage = -1;

    // Start is called before the first frame update
    void Start()
    {
        timer = TimeUntilHint;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer until next hint is shown 

        if(Enabled == true)
        {
            if (timer <= 0.0f)
            {
                timerEnded();
                return;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            return;
        }
        
       
    }

    private void timerEnded()
    {
        if(currentMessage <= (Message.Count - 1))
        {
            currentMessage++;
            hintOutput.text = Message[currentMessage];
            timer = TimeUntilHint;
            return;
        }
        else
        {
            Enabled = false;
        }
    }
}
