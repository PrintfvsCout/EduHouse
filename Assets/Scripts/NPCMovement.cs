using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

	// Lista od pozicii pomegju koj ke se dvizi
	public Transform[] npcMovingPath;
	// Brzina so koja ke se dvizi
	public float speed;
	// Pauza so dvizenjeto
	public bool pause;

	// Animator komponentata

	private Animator animator;

	// Momentalna pozicija kon koja se dvizi
	private Transform currentTarget;
	// Indeksot (pozicijata vo npcMovingPath) na slednata pozicija
	private int nextTargetIndex;

	void Start () {

		// Se zema animator komponentata

		animator = GetComponent<Animator> ();

		// Mestime naredna pozicija da e prvata vo listata
		nextTargetIndex = 0;
		nextTarget();
	
	}

	void FixedUpdate () {

		
       
        // Ako pauzirame ili nemame naredna pozicija namesti animacija na stoenje vo sprotivno animacija na dvizenje.

		if (pause || currentTarget == null || transform.position == currentTarget.position) {
			animator.SetBool("Walking", false);
			return;
		} else {
			animator.SetBool("Walking", true);
		}

		// Cekor na pridvizuvanje
		float step = Time.deltaTime * speed;
		// Nova pozicija na koja sto treba da se naogja objektot
		Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget.position, step);

		// Nasoka kon koja se pridvizuva
		Vector3 direction = newPosition - transform.position;
		direction.Normalize ();

		// Mestime nova pozicija
		transform.position = newPosition;

		// Mestime rotacija vo odnos na nasokata
		transform.eulerAngles = new Vector3 (0, 0, -Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI);

		// Ako sme stignale na potrebnata pozicija namesti nova pozicija na dvizenje
		if (transform.position == currentTarget.position) {
			nextTarget();
		}
		
	}

	private void nextTarget() {

		// Ako ima pozicija na dvizenje namesti vo sporivno namesti null
		if (npcMovingPath.Length == 0) {
			currentTarget = null;
		} else {
			currentTarget = npcMovingPath[nextTargetIndex];
		}

		// Zgolemi go indeksot na narednata pozicija
		nextTargetIndex++;
		// Ako sme gi pominale site pozicii vrati se na prvata
		if (nextTargetIndex >= npcMovingPath.Length) {
			nextTargetIndex = 0;
		}

	}
}
