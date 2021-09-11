using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectsToList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(GameObject.Find("Mom").GetComponent<MomAI>().detectedObjects.Count);
    }

    private void OnTriggerEnter(Collider other) {
	    if (other.gameObject.CompareTag("Toys") || other.gameObject.CompareTag("Player")) {
		    
		    GameObject.Find("Mom").GetComponent<MomAI>().detectedObjects.Add(other.gameObject);
		    Debug.Log("Item Added");

	    }
    }

    private void OnTriggerExit(Collider other) {
	    if (other.gameObject.CompareTag("Toys") || other.gameObject.CompareTag(("Player"))) {
		    // check if array is empty before removing.
		    if (GameObject.Find("Mom").GetComponent<MomAI>().detectedObjects.Count > 0) {
			    GameObject.Find("Mom").GetComponent<MomAI>().detectedObjects.Remove(other.gameObject);
			    Debug.Log("Item Removed");
		    }

	    }
    }
}
