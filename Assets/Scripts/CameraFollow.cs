using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Objektot koj ke go sledime.
	public GameObject objectToFollow;
	
	void FixedUpdate () {
	
		// Ako ma objekt za sledenje
		if (objectToFollow != null) {
			// Generirame nova pozicija na kamerata
			Vector3 newPositon = new Vector3(objectToFollow.transform.position.x, 
			                                 objectToFollow.transform.position.y, transform.position.z);
			transform.position = newPositon;
		}

	}

}
