using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGoal : MonoBehaviour
{
    public List<inventoryItem> goalItems;
    public int numberOfGoals;
    public bool playerHasWon;
    AudioSource audioSource;
    Light doorLight;
    PlayerInventory pInventory;
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

        goalItems = pInventory.items;
        if (goalItems.Count>= numberOfGoals && !playerHasWon)
        {
            doorLight.color = new Color(0, 1, 0, 1);
            doorLight.intensity = 4f;
            audioSource.Play();
            playerHasWon = true;
        }
      
        
           // doorLight.color = new Color(1, 0, 0, 0.58f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<modularPlayerControllerVR>() && playerHasWon)
        {
           
        }
    }
}
