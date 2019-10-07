using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modularGrabObject : MonoBehaviour
{
    inventoryItem objInventoryItem;
    public bool isInventoryCompatible;
    bool alreadyInInventory;
    public Transform holderObject;
    public bool beingHeld = false;
    public bool canHold = true;
    Rigidbody mRigidbody;
    bool asleep;
    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        asleep = true;
        mRigidbody.velocity = Vector3.zero;
        mRigidbody.Sleep();

        if(GetComponent<inventoryItem>())
        {
            objInventoryItem = GetComponent<inventoryItem>();
            isInventoryCompatible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (holderObject != null)
        {
            if(isInventoryCompatible)
            {
                if(holderObject.GetComponent<modularGrabController>() && !alreadyInInventory)
                {
                    Debug.Log("Should add to inventory");
                    holderObject.GetComponent<modularGrabController>().pCharacter.GetComponent<PlayerInventory>().AddItemToInventory(this.objInventoryItem);
                    alreadyInInventory = true;
                    gameObject.transform.position = FindObjectOfType<DoorGoal>().transform.position;
                    gameObject.SetActive(false);
                }
            }
            if(asleep)
            {
                mRigidbody.velocity = Vector3.zero;
            }
            if (holderObject.GetComponent<modularGrabController>())
            {
                if (beingHeld)
                {
                    asleep = false;
                    transform.position = holderObject.position;
                    mRigidbody.velocity = Vector3.zero;
                    mRigidbody.transform.eulerAngles = holderObject.transform.eulerAngles;
                    mRigidbody.useGravity = true;
                    mRigidbody.detectCollisions = true;
                }
               
            }
        }
    }
}
