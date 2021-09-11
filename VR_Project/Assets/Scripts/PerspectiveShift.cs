using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PerspectiveShift : MonoBehaviour {
	
	// get current perspective: 0 for human, 1 for robot
	private String currentPerspective = "boy" ;
	public XRNode inputSource;
	
	private bool buttonPress;
	private bool buttonPressDownRelease;
	
	private CharacterController character;
	private bool secondSwap;
	private Vector3 lastBoyPosition, lastRobotPosition;

	public GameObject boy;
	public GameObject robot;
	private GameObject vrRig;

	private bool isRobotGrabbed;

	private Collider robot_collider;
	private Collider boy_collider;
    // Start is called before the first frame update
    void Start() {
	    character = GetComponent<CharacterController>();
	    lastBoyPosition = boy.transform.position;
	    lastRobotPosition = robot.transform.position;
	    robot_collider = robot.GetComponent<Collider>();
	    boy_collider = boy.GetComponent<Collider>();
	    Debug.Log(robot_collider.bounds.max.y);
    }

    // Update is called once per frame
    void Update() {
	    GameObject vrRig = GameObject.Find("VR Rig");

	    InputDevice controller = InputDevices.GetDeviceAtXRNode(inputSource);
	    controller.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPress);

	    if (robot.GetComponent<XRGrabInteractable>().isSelected) {
		    // if the robot is current grabbed, then disable perspective shift to robot (to prevent unforeseen issues)
		    isRobotGrabbed = true;

	    }

	    else if (!robot.GetComponent<XRGrabInteractable>().isSelected) {
		    

		    if (currentPerspective == "boy" && isRobotGrabbed) {
			    // if the player is the boy, update robot position constantly. This is done to always check where the robot is. 
			    lastRobotPosition = robot.transform.position;
			    isRobotGrabbed = false;
		    }
	    }

			// check if the button has been pressed down. If so, set pressdownrelease to true
		    if (buttonPress && !buttonPressDownRelease) {
			    buttonPressDownRelease = true;
		    }

		    // if the buttonPress is false (the button has been released) and buttonPressDownRelease has not be activated, do something.
		    // In other words, this is the getKeyUp implementation

		    if (!buttonPress && buttonPressDownRelease) {
			    buttonPressDownRelease = false;

				// make sure the robot is not grabbed before changing perspective	
			    if (currentPerspective == "boy" && !isRobotGrabbed) {
				    
				    // turn off robot collider
				    robot_collider.enabled = false;
				    
				    currentPerspective = "robot";
				    // if you're swapping to the robot from the boy, make sure to add the offset height 
				    
					    lastBoyPosition = new Vector3(vrRig.transform.position.x,
						    vrRig.transform.position.y + boy_collider.bounds.center.y, vrRig.transform.position.z);

					    // place the VR rig at the robot's position
				    vrRig.transform.position = new Vector3(lastRobotPosition.x,
					    lastRobotPosition.y - robot_collider.bounds.center.y, lastRobotPosition.z);

				    // shift the vr rig scale to reflect the robot's height
				    vrRig.transform.localScale = new Vector3(0.231f, 0.231f, 0.231f);

				    character.height = robot_collider.bounds.max.y;
				    character.center = robot_collider.bounds.center;
				    lastRobotPosition = robot.transform.position;
				    
				    // show/hide the respective models 
				    boy.SetActive(true);
				    // turn on boy collider
				    boy_collider.enabled = true;
				    robot.SetActive(false);

			    }

			    else if (currentPerspective == "robot") {
				    // turn off boy collider
				    boy_collider.enabled = false;
				    
				    currentPerspective = "boy";
				    
				    // place the robot's position at the player's last location
				    
				    // If you're swapping from robot to boy, then add the offset height
				    lastRobotPosition = new Vector3(vrRig.transform.position.x,
					    vrRig.transform.position.y + robot_collider.bounds.center.y, vrRig.transform.position.z);
				    //place the VR rig at the boy's position
				    vrRig.transform.position = new Vector3(lastBoyPosition.x,
					    lastBoyPosition.y - boy_collider.bounds.center.y, lastBoyPosition.z);
				    
				    

				    vrRig.transform.localScale = new Vector3(1, 1, 1);

				    character.height = boy_collider.bounds.max.y;
				    character.center = boy_collider.bounds.center;

				    lastBoyPosition = boy.transform.position;
				    
				    
				    // show/hide the respective models 
				    boy.SetActive(false);
				    
				    robot.SetActive(true);
				    robot_collider.enabled = true;

			    }
			    
		    }
	    
    }
}
