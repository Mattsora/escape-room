using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<inventoryItem> items;
    public bool alreadyNotifiedOfVictory;
    public objectiveSystem obSystem;
    // Start is called before the first frame update
    void Start()
    {
        obSystem = FindObjectOfType<objectiveSystem>();
    }
    public void AddItemToInventory(inventoryItem item)
    {
        items.Add(item);
    }
    // Update is called once per frame
    void Update()
    {
        if (obSystem.objectiveIsKey)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].isKey)
                {
                    obSystem.messageDisplay = "You found :" + items[i].name + " !!! Now Escape!";
                }
            }
        }
    }
}
