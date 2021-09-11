using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MomAI : MonoBehaviour {

	private NavMeshAgent momAgent;
	private bool momDistracted, momCooldown;
	public float momAIDistractedCooldown = 5;
	public List<GameObject> detectedObjects = new List<GameObject>();
	private Vector3 originalPosition;
	private Vector3 originalRotation;
	private bool aroundRange;

    // Start is called before the first frame update
    void Start() {
	    momAgent = GetComponent<NavMeshAgent>();
	    originalPosition = GameObject.Find("Mom").transform.position;
	    originalRotation = GameObject.Find("Mom").transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
	    if (momCooldown) {
		    if (momAIDistractedCooldown > 0) {
			    momAIDistractedCooldown -=  1.0f * Time.deltaTime;
			    Debug.Log("Ticking Down");
		    }
		    else {
			    Debug.Log("Off Cooldown");
			    momCooldown = false;
			    momAIDistractedCooldown = 5;
		    }
	    }
	    if (detectedObjects.Count > 0 && !momCooldown) {
		    // if targetObject is passed to MomAi, then move the mom model to the object.
		    momAgent.SetDestination(detectedObjects[0].transform.position);
	    }

	    if (detectedObjects.Count == 0 && !momCooldown &&
		    GameObject.Find("Mom").transform.position != originalPosition ) {
		    // reset back to base position
		    momAgent.SetDestination(originalPosition);
		    GameObject.Find("Mom").transform.eulerAngles = originalRotation;
	    }
	    

    }

    private void OnTriggerEnter(Collider other) {
	    Debug.Log("collision met!");
	    if (detectedObjects.Count > 0) {
		    if(other.gameObject == detectedObjects[0]){
			    if (other.gameObject.CompareTag("Toys")) {
				    other.gameObject.transform.position = new Vector3(10.99f, 3, 16.44f);
				    detectedObjects.RemoveAt(0);
				    momCooldown = true;

			    }
			    else if (other.gameObject.CompareTag("Player")) {
				    GameObject.FindWithTag("Player").GetComponent<ResetToStart>().SetIsCaught(true);
				    detectedObjects.RemoveAt(0);
				    momCooldown = true;

			    }

		    }
	    }
    }
}
