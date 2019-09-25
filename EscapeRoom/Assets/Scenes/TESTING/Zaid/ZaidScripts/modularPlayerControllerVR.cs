using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
public class modularPlayerControllerVR : MonoBehaviour
{
    public Camera pCamera; //The main camera of the scene
    public Rigidbody pRigidbody; //PlayerRigidbody;
    public bool VR_ModeEnabled; //Determines if VR accomidations must be met or not.
    public float pWalkSpeed; //The walk speed of the player
    public bool movingStick; //Determines if moveInput is being changed by player.
    
    public LayerMask pSolidLayer; //The Solid Layer for the controller (Useful for ground checking)
    public Vector3 moveDirection; //The move direction for the player controller.
    Vector3 cameraForward, cameraRight;
    Vector2 moveInput; //The input we get from Vive and Controller 
    // Start is called before the first frame update
    void Start()
    {
        pCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() ; //Get the active scene camera at the begining of the scene
        pRigidbody = GetComponent<Rigidbody>();
        
    }
    void getInput()
    {
        movingStick = false;
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
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

        moveDirection = cameraForward * moveInput.y + cameraRight * moveInput.x;
        Debug.Log(moveDirection);
    }
    
    void movePlayer()
    {
        if(movingStick)
        {
            pRigidbody.velocity = moveDirection * pWalkSpeed * Time.deltaTime;
        }
        pRigidbody.freezeRotation = true;
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
        }
        getInput();
        getCameraDirection();
        movePlayer();
    }
}
