using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorGoal : MonoBehaviour
{
    public List<inventoryItem> goalItems;
    public int numberOfGoals;
    public bool playerHasWon;
    public string winTransition;
    AudioSource audioSource;
    Light doorLight;
    PlayerInventory pInventory;
    float countDownTime;
    public float countDownWaitTime;
    bool countDownToEnd;
    VrFade vrFade;
    // Start is called before the first frame update
    void Start()
    {

        pInventory = FindObjectOfType<PlayerInventory>();
        doorLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        vrFade = FindObjectOfType<VrFade>();
        goalItems = pInventory.items;
        if (goalItems.Count>= numberOfGoals && !playerHasWon)
        {
            doorLight.color = new Color(0, 1, 0, 1);
            doorLight.intensity = 8f;
            audioSource.Play();
            playerHasWon = true;
            FindObjectOfType<hintController>().Enabled = false;
            FindObjectOfType<hintController>().showEscapeText = true;
        }
      
        if(countDownToEnd)
        { countDown(); }
           // doorLight.color = new Color(1, 0, 0, 0.58f);
        
    }
    
    public void countDown()
    {
        if(countDownWaitTime>countDownTime)
        {
            countDownTime = countDownTime + Time.deltaTime;
            vrFade.FadeIn();
        }
        else
        {
            SceneManager.LoadScene(winTransition, LoadSceneMode.Single);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<modularPlayerControllerVR>() && playerHasWon)
        {
            FindObjectOfType<Timer>().timerStop = true;
            FindObjectOfType<hintController>().Enabled = false;
            FindObjectOfType<hintController>().showWinText = true;
            countDownToEnd = true;
            
        }
    }
}
