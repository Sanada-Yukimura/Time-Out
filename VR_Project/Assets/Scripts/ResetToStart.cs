using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetToStart : MonoBehaviour {

	private bool isCaught;

	private float timeCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

	    if (isCaught) {
		    if (timeCount < 1.5) {
			    timeCount +=  1.0f * Time.deltaTime;

		    }
		    else {
			    GameObject.FindWithTag("Player").transform.position = new Vector3(233.34f, 0.22f, 311.23f);
			    timeCount = 0;
			    isCaught = false;
		    }


	    }
    }

    public void SetIsCaught(bool caughtBool) {
	    isCaught = caughtBool;
    }

}
