using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool Enabled = true;
    public Camera MainCam;
    public Camera keyCamera;

    public modularPlayerControllerVR Player;

    public VRKeys.Keyboard VRKeyboard;

    private void Start()
    {
        Player = FindObjectOfType<modularPlayerControllerVR>();
    }
    void Update()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (Enabled)
        {
            keyCamera = GameObject.Find("KeyboardCamera").GetComponent<Camera>();

            keyCamera.enabled = false;

            MainCam.enabled = true;
            Player.canMove = true;
            VRKeyboard.enabled = false;
            

        }
        else
        {
            VRKeyboard.enabled = true;
            MainCam.enabled = false;
            Player.canMove = false;
            keyCamera.stereoTargetEye = StereoTargetEyeMask.Both;
            keyCamera.enabled = true;
        }
        
    }

}
