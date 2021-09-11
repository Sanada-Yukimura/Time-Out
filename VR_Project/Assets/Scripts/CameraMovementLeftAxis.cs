using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraMovementLeftAxis : MonoBehaviour {
	public float rotationIncrement;
	private GameObject vrCamera;
	public XRNode inputSource;

	private Vector2 axisUsage;
    // Start is called before the first frame update
    void Start() {
	    vrCamera = GameObject.Find("VR Camera");
    }

    // Update is called once per frame
    void Update() {
	    InputDevice controller = InputDevices.GetDeviceAtXRNode(inputSource);
	    controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisUsage);
	    Vector3 direction = new Vector3(0,axisUsage.x* rotationIncrement, 0);
	    vrCamera.transform.Rotate(direction);
	    
	    
    }
}
