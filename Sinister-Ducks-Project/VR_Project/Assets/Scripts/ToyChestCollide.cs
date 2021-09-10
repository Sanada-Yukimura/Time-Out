using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToyChestCollide : MonoBehaviour {
	private int toyCarCount = 0;
	public Text toyCount;
	public int maximumCount;

	// Start is called before the first frame update
    void Start()
    {
			toyCount.text = "Toys Found: " + toyCarCount + "/8";
    }

    // Update is called once per frame
    void Update()
    {

        // if score reaches maximum, go to win condition:
        if (toyCarCount == maximumCount) {
	        Debug.Log("You Win!");
					SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other) {
	    if (other.gameObject.tag == "toyCar") {
		    Debug.Log("Toy Car Collected!");
		    Destroy(other.gameObject);
		    toyCarCount += 1;
				toyCount.text = "Toys Found: " + toyCarCount + "/8";
	    }
    }


}
