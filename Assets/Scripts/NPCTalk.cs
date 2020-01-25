using UnityEngine;
using System.Collections;

public class NPCTalk : MonoBehaviour {

	// Skripta za dvizenje na objektot
	private NPCMovement movement;
	
	void Start () {

		// Ja zemame skriptata
		movement = GetComponent<NPCMovement> ();

	}
	
	void OnCollisionEnter2D(Collision2D coll) {

		// Pri sudir so igracot go pauzirame dvizenjeto
		if (coll.gameObject.tag == "Player") {
			movement.pause = true;
		}
		
	}
	
	void OnCollisionExit2D(Collision2D coll) {

		// Pri odalecuvanje go prodolzuvame dvizenjeto
		if (coll.gameObject.tag == "Player") {
			movement.pause = false;
		}
		
	}
}
