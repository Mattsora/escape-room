using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class hintController : MonoBehaviour
{
    public bool Enabled = true;

    public float TimeUntilHint = 60.0f;
    public float timer;
    public AudioSource audioSource;
    public TextMeshPro hintOutput;
    public List<string> Message = new List<string>();
    internal int currentMessage = -1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = TimeUntilHint;
        hintOutput.text = "";
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
            /*
            System.Media.SoundPlayer player = new System.Media.SoundPlayer
                (@"d:\school\Periode_05\project escape room\kraken\escape-room\EscapeRoom\Assets\SoundEffects\notification\ting.mp3");
                */
            // player.Play();
            audioSource.Play();
            timer = TimeUntilHint;
            return;
        }
        else
        {
            Enabled = false;
        }
    }
}
