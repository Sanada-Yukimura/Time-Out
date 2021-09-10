using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class LocomotionController : MonoBehaviour {
	public XRController rightTeleportRay;
	public InputHelpers.Button teleportActivation;
	public float activationThreshold = 0.1f;
	
	// Created following this tutorial: https://www.youtube.com/watch?v=fZXKGJYri1Y
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (rightTeleportRay) {
		    rightTeleportRay.gameObject.SetActive(CheckActivation(rightTeleportRay));
	    }
    }

    
    // Check if the controller trigger has been pressed.
    public bool CheckActivation(XRController controller) {
	    InputHelpers.IsPressed(controller.inputDevice, teleportActivation, out bool isActivated, activationThreshold);
	    return isActivated;
    }
    
}
