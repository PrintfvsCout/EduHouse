using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// OVAA KLASA E OSNOVA NA EDEN DIALOG. ZA CELOSNO DA RABOTI TREABA DA BIDE EKSTENDIRANA
public class QuestionDialogBase : MonoBehaviour {

	// Pole za zaklucuvanje na rotacijata. (dialogot da ne rotira koga rotira NPCto)
	private Quaternion fixedRotation;

	// Canvas elementot na dialogot
	protected Canvas canvas;
	// Pole za prasanje
	protected Text question;

	// Event koj ke gi izvestuva prikacenite liseneri koga prasanjeto ke bide tocno odgovoreno.
	public delegate void QuestionDialogHandler();
	public event QuestionDialogHandler QuestionAnswered;
	
	
	void Awake ()
    {

		// Zemame momentalna rotacija
		fixedRotation = transform.rotation;
		// Go zemame poleto za prasanje
		question = GetComponentInChildren<Text> ();
		// Go zemame kanvasot
		canvas = GetComponent<Canvas> ();
		
	}
	
	void LateUpdate() {

		// Postavuvame momentalna rotacija na pocetna rotacija
		transform.rotation = fixedRotation;
		
	}

	// Funkcija za pokazuvanje / krienje na dialogot
	public virtual void SetVisible(bool visible) {
		
		canvas.enabled = visible;
		
	}

	// Funkcija koja go izvrsuva eventot za odgovoreno prasanje
	protected void Answered()
    {
		if (QuestionAnswered != null)
        {
			QuestionAnswered();
		}
	}
}
