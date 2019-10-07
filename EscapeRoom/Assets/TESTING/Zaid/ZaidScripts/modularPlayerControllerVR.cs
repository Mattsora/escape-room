using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using Valve.VR.InteractionSystem;
using Valve.VR;
using Cinemachine;
public class modularPlayerControllerVR : MonoBehaviour
{
    public Camera pCamera; //The main camera of the scene
    public Rigidbody pRigidbody; //PlayerRigidbody;
    public bool VR_ModeEnabled; //Determines if VR accomidations must be met or not.
    public float pWalkSpeed; //The walk speed of the player
    public bool movingStick; //Determines if moveInput is being changed by player.
    public SteamVR_Input_Sources moveHandType;
    public SteamVR_Action_Vector2 moveVR;
    public SteamVR_Action_Vector2 lookVR;
    public LayerMask physicsLayer;
    public LayerMask pSolidLayer; //The Solid Layer for the controller (Useful for ground checking)
    public Vector3 moveDirection; //The move direction for the player controller.
    Vector3 cameraForward, cameraRight;
    Vector2 moveInput; //The input we get from Vive and Controller 
    Vector2 lookInput;
    // Start is called before the first frame update
    void Start()
    {
        pCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() ; //Get the active scene camera at the begining of the scene
        pRigidbody = GetComponent<Rigidbody>();
        moveVR = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("default", "move");
        lookVR = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("default", "look");
    }
    void getInput()
    {
        movingStick = false;
        if (!VR_ModeEnabled)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
            pCamera.transform.position = transform.position + Vector3.up * 0.58f;
        }
        else
        {
            moveInput = moveVR.GetAxis(SteamVR_Input_Sources.LeftHand);
            lookInput = lookVR.GetAxis(SteamVR_Input_Sources.RightHand);
        }
       
        if(moveInput.magnitude>0)
        {
            movingStick = true;
        }
    }
    //Get Camera Look Direction
    void getCameraDirection()
    {
        cameraForward = pCamera.transform.forward;
        cameraRight = pCamera.transform.right;

        cameraForward.Normalize();
        cameraRight.Normalize();

        cameraForward.y = 0;
        cameraRight.y = 0;

            moveDirection = cameraForward * (moveInput.y * 2f) + cameraRight * moveInput.x;
      
        
        
       
    }
    
    void movePlayer()
    {
        pRigidbody.freezeRotation = true;
        if(movingStick)
        {
            
            moveDirection.y = 0;
           
            pRigidbody.velocity = moveDirection * pWalkSpeed * Time.deltaTime;
        }
        if (VR_ModeEnabled)
        {
            if (lookInput.x > 0.52f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 100.52f * Time.deltaTime, transform.eulerAngles.z);
            }
            if (lookInput.x < -0.52f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 100.52f * Time.deltaTime, transform.eulerAngles.z);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == physicsLayer.value)
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<Collider>(), true);
        }
        if(collision.rigidbody.GetComponent<modularGrabObject>() && !VR_ModeEnabled)
        {
            if(collision.rigidbody.GetComponent<modularGrabObject>().isInventoryCompatible)
            {
                collision.rigidbody.GetComponent<modularGrabObject>().ForceAddToInventory(this.GetComponent<modularPlayerControllerVR>());
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if(VR_ModeEnabled)
        {
            pCamera.stereoTargetEye = StereoTargetEyeMask.Both;
        }
        else
        {
            pCamera.stereoTargetEye = StereoTargetEyeMask.None;
            pCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 95f;
        }
        getInput();
        getCameraDirection();
        movePlayer();
    }
}
