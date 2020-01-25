using UnityEngine;
using System.Collections;

public class NPCOpenDoor : MonoBehaviour
{

	// Vrata objektot koj ke go otvarame
	public GameObject doorObject;

	// Dialog objekt so prasanja
	private QuestionDialogBase question;
	// Door skriptata na doorObject
	private Door door;

	void Start()
    {

		// Zemame dialog objektot
		question = GetComponentInChildren<QuestionDialogBase> ();
		// Dodavame lisener na dialogot. (Metoda koja ke se povikuva koga ke se odgovori prasanje
		question.QuestionAnswered += QuestionAnswered;
		// Ako sme dodelile objekt vrata zemi ja skriptata Door od nego
		if (doorObject != null)
        {
			door = doorObject.GetComponent<Door> ();
		}
		// Prasanjeto ne treba da se gleda na pocetok.
		question.SetVisible (false);

    }

	void OnCollisionEnter2D(Collision2D coll)
    {

		// Koga ke se sudri so Player pojavi go prasanjeto
		if (coll.gameObject.tag == "Player" &&  door != null && door.IsLocked() )
        {
			question.SetVisible(true);
		}
		
	}

	void OnCollisionExit2D(Collision2D coll) {

		// Koga Player ke se odaleci skri go prasanjeto
		if (coll.gameObject.tag == "Player") {
			question.SetVisible(false);
		}
		
	}

	public void QuestionAnswered()
    {

		// Koga ke odgovori na prasanjeto otkluci ja vratata i skri go prasanjeto
		if (door != null && door.IsLocked())
        {
			door.Unlock();
			question.SetVisible(false);
		}

	}


	// Koga ke se unisti ovoj objekt trgni go postaveniot lisener.
	void OnDestroy()
    {

		if (question != null) {
			question.QuestionAnswered -= QuestionAnswered;
		}

	}

}
