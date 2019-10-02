using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modularGrabObject : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        if (holderObject != null)
        {
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
