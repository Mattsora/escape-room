/**
 * Copyright (c) 2017 The Campfire Union Inc - All Rights Reserved.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for
 * full license information.
 *
 * Email:   info@campfireunion.com
 * Website: https://www.campfireunion.com
 */

using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace VRKeys {

	/// <summary>
	/// Example use of VRKeys keyboard.
	/// </summary>
	public class DemoScene : MonoBehaviour {

		/// <summary>
		/// Reference to the VRKeys keyboard.
		/// </summary>
		public Keyboard keyboard;
        public GeneratePasscode numbers;

		/// <summary>
		/// See the following for why this is so convoluted:
		/// http://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/EmailAddressAttribute.cs,54
		/// http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/
		/// </summary>

		/// <summary>
		/// Show the keyboard with a custom input message. Attaching events dynamically,
		/// but you can also use the inspector.
		/// </summary>
		private void OnEnable () {
			// Automatically creating camera here to show how
			GameObject camera = new GameObject ("KeyboardCamera");
			Camera cam = camera.AddComponent<Camera> ();
			cam.nearClipPlane = 0.1f;
			camera.AddComponent<AudioListener> ();

			// Improves event system performance
			Canvas canvas = keyboard.canvas.GetComponent<Canvas> ();
			canvas.worldCamera = cam;

			keyboard.Enable ();

			keyboard.OnUpdate.AddListener (HandleUpdate);
			keyboard.OnSubmit.AddListener (HandleSubmit);
			keyboard.OnCancel.AddListener (HandleCancel);
		}

		private void OnDisable () {
			keyboard.OnUpdate.RemoveListener (HandleUpdate);
			keyboard.OnSubmit.RemoveListener (HandleSubmit);
			keyboard.OnCancel.RemoveListener (HandleCancel);

			keyboard.Disable ();
		}

		/// <summary>
		/// Press space to show/hide the keyboard.
		///
		/// Press Q for Qwerty keyboard, D for Dvorak keyboard, and F for French keyboard.
		/// </summary>
		private void Update () {
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (keyboard.disabled) {
					keyboard.Enable ();
				} else {
					keyboard.Disable ();
				}
			}

			if (keyboard.disabled) {
				return;
			}

			if (Input.GetKeyDown (KeyCode.Q)) {
				keyboard.SetLayout (KeyboardLayout.Qwerty);
			} else if (Input.GetKeyDown (KeyCode.F)) {
				keyboard.SetLayout (KeyboardLayout.French);
			} else if (Input.GetKeyDown (KeyCode.D)) {
				keyboard.SetLayout (KeyboardLayout.Dvorak);
			}
            numbers = GameObject.FindObjectOfType<GeneratePasscode>();
          
		}

		/// <summary>
		/// Hide the validation message on update. Connect this to OnUpdate.
		/// </summary>
		public void HandleUpdate (string text) {
			keyboard.HideValidationMessage ();
		}

		/// <summary>
		/// Validate the email and simulate a form submission. Connect this to OnSubmit.
		/// </summary>
		public void HandleSubmit (string text) {
			keyboard.DisableInput ();

			StartCoroutine (SubmitEmail (text));
		}

		public void HandleCancel () {
			Debug.Log ("Cancelled keyboard input!");
            
		}

		/// <summary>
		/// Pretend to submit the email before resetting.
		/// </summary>
		private IEnumerator SubmitEmail (string email) {

           if (keyboard.text == FindObjectOfType<SetPasscode>().GenerateCombinedNumber())
            {
                keyboard.ShowSuccessMessage("Succes!");

                yield return new WaitForSeconds(3f);

                keyboard.HideSuccessMessage();
                keyboard.SetText("");
                keyboard.EnableInput();

                FindObjectOfType<Timer>().timerStop = true;
                FindObjectOfType<hintController>().Enabled = false;
                FindObjectOfType<hintController>().showWinText = true;
                FindObjectOfType<DoorGoal>().countDownToEnd = true;
            }
			
		}
	}
}