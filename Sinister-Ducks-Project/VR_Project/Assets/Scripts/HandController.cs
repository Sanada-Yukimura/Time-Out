using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//[RequireComponent(typeof(DeviceBasedController))]
public class HandController : MonoBehaviour
{

    ActionBasedController controller;
    public Hands hands;

    void Start()
    {
      controller = GetComponent<ActionBasedController>();
    }

    void Update()
    {
      hands.SetGrip(controller.selectAction.action.ReadValue<float>());
      hands.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
