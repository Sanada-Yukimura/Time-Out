using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayTrigger : MonoBehaviour
{
    public XRNode inputSource;

    private bool buttonPress;
  	private bool buttonPressDownRelease;

    // void OnTriggerEnter(Collider other)
    // {
    //   if (buttonPress && !buttonPressDownRelease) {
    //     buttonPressDownRelease = true;
    //   }
    //
    //   if (!buttonPress && buttonPressDownRelease) {
    //     buttonPressDownRelease = false;
    //     Debug.Log("hit");
    //   }
    // }

    public void ShowMessage()
    {
    //  Debug.Log("hit");
      if (buttonPress && !buttonPressDownRelease) {
         buttonPressDownRelease = true;
      }
      if (!buttonPress && buttonPressDownRelease) {
       buttonPressDownRelease = false;
       Debug.Log("hit");
      }
    }

    void Update()
    {
      InputDevice controller = InputDevices.GetDeviceAtXRNode(inputSource);
      controller.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPress);
    }
}
