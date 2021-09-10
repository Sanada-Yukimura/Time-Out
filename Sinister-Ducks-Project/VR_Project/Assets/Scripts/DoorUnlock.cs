using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorUnlock : MonoBehaviour {
	public GameObject thisDoor;
	private AudioSource unlock;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
	    if (other.gameObject == thisDoor) {
		    HingeJoint doorHinge = thisDoor.GetComponent<HingeJoint>();
		    JointLimits doorLimit = doorHinge.limits;
		    doorLimit.max = 119.4395f;
			unlock.Play();
			Destroy(gameObject);
	    }
    }
}
