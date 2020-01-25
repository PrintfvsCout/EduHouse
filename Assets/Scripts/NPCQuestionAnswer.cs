using UnityEngine;
using System.Collections;

public class NPCQuestionAnswer : MonoBehaviour {

	// Objekt sto gi pokazuva odoorite na prasanjata
	private AnswerDialog answer;

	void Start() {

		// Go zemame objektot
		answer = GetComponentInChildren<AnswerDialog> ();
		// Na pocetok e nevidliv
		answer.SetVisible (false);
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		// Pri sudir so igracot go pokazuvame
		if (coll.gameObject.tag == "Player") {
			answer.SetVisible(true);
		}
		
	}
	
	void OnCollisionExit2D(Collision2D coll) {
		// Koga ke se odaleci go krieme
		if (coll.gameObject.tag == "Player") {
			answer.SetVisible(false);
		}
		
	}


}
