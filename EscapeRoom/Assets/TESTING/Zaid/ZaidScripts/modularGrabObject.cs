using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modularGrabObject : MonoBehaviour
{
    public Transform holderObject;
    public bool beingHeld = false;
    public bool canHold = true;
    Rigidbody mRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holderObject != null)
        {
            if (holderObject.GetComponent<modularGrabController>())
            {
                if (beingHeld)
                {
                    transform.position = holderObject.position;
                    mRigidbody.velocity = Vector3.zero;

                }
               
            }
        }
    }
}
