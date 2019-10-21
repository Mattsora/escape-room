using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialTextTimer : MonoBehaviour
{
    public List<string> messagesToSay;
    public Text screenText;
    public AudioSource audioSource;
    public float countDownTime;
    float currentCountDown;
    bool advanceText;
    bool finished;
    int textIndex;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<hintController>().lockHintController = true;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (textIndex >= messagesToSay.Count)
        {
            FindObjectOfType<hintController>().lockHintController = false;
            FindObjectOfType<Timer>().timerStop = false;
            FindObjectOfType<modularPlayerControllerVR>().canMove = true;
            gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<hintController>().lockHintController = true;
            FindObjectOfType<Timer>().timerStop = true;
            FindObjectOfType<modularPlayerControllerVR>().canMove = false;
            
        }
        if (countDownTime>currentCountDown)
        {
            currentCountDown = currentCountDown + Time.deltaTime;
        }
        else
        {
            textIndex++;
            advanceText = true;
            currentCountDown = 0;
        }
        if(advanceText)
        {

            if (messagesToSay.Count > 0 && textIndex <= messagesToSay.Count)
            {
                screenText.text = messagesToSay[textIndex];
                audioSource.Play();
                advanceText = false;
            }
          
        }
    }
}
