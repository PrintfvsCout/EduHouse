using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{


	// Animatorot na vratata
	private Animator animator;


	void Start()
    {

		// Go zemame animatorot od objektot
		animator = GetComponent<Animator> ();

    }

    // Funkcija koja drugi skripti ja povikuvaat za da se otkluci vratata

    public void Unlock ()
    {
		// Ja mestime vrednosta Locked od animatorot na false
		animator.SetBool("Locked", false);

	}
    

	// Funkcija koja kazuva dali vratata e otklucena.
	public bool IsLocked()
    {
        // Ja vrakja vrednosta na Locked od animatorot
		return animator.GetBool("Locked");
	}
}
