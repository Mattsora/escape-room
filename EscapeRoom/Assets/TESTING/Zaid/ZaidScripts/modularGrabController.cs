using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
public class modularGrabController : MonoBehaviour
{
    public modularPlayerControllerVR pCharacter;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabing;
    public Vector3 calculatedVelocity;
    Vector3 lastPosition;
    
    public bool grabbingSomething;
    public bool tryingToGrabSomething;
    public float maxGrabDistance;
    public LayerMask SolidLayer;
    SteamVR_Behaviour_Pose pose;
    RaycastHit objectHit;
    Collider grabCollider;
    modularGrabObject grabbedObject;
    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        
       
    }
    public bool GetGrab()
    {
       
        return grabing.GetState(handType);
       
    }
    
    private void OnTriggerStay(Collider other)
    {
        
            if (other.gameObject.GetComponent<modularGrabObject>() && tryingToGrabSomething && !grabbingSomething)
            {
                grabbedObject = other.gameObject.GetComponent<modularGrabObject>();
                grabbedObject.holderObject = this.transform;
                grabbedObject.beingHeld = true;
            grabbingSomething = true;
           
               
            }
         
        
    }
    // Update is called once per frame
    void Update()
    {
        calculatedVelocity = (transform.position-lastPosition) * 100f;
        if (GetGrab())
        {
            if (!grabbingSomething)
            {
                tryingToGrabSomething = true;
            }
            if(grabbingSomething)
            {
                
                grabbedObject.beingHeld = true;
                grabbedObject.holderObject = transform;
            }

        }
       else
        {
          
                tryingToGrabSomething = false;
            if (grabbedObject)
            {
                grabbedObject.beingHeld = false;
                grabbedObject.GetComponent<Rigidbody>().AddForce(calculatedVelocity, ForceMode.VelocityChange);
                grabbedObject.holderObject = null;
                grabbedObject = null;
                grabbingSomething = false;
            }

            
        }
        
        lastPosition = transform.position;
    
    }
}
