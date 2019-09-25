using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modularPlayerControllerVR : MonoBehaviour
{
    public float pWalkSpeed; //The walk speed of the player
    public Camera pCamera; //The main camera of the scene
    public LayerMask pSolidLayer; //The Solid Layer for the controller (Useful for ground checking)
    public Vector3 moveDirection; //The move direction for the player controller.
    Vector3 cameraForward, cameraRight;
    Vector2 moveInput; //The input we get from Vive and Controller 
    // Start is called before the first frame update
    void Start()
    {
        pCamera = Camera.main.GetComponent<Camera>(); //Get the active scene camera at the begining of the scene
    }
    void getInput()
    {

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
    }


    // Update is called once per frame
    void Update()
    {
        getInput();
        getCameraDirection();
    }
}
