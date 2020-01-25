using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Koga nekoe telo ke stapne vrz trigger kolajderot.
	void OnTriggerEnter2D(Collider2D other)
    {
		// Racuname koe e sledno nivo.
		int nextLevel = Application.loadedLevel + 1;
		// Ako sme na posledno nivo premini na prvo.
		if (nextLevel >= Application.levelCount) {
			nextLevel = 0;
		}
		// Se vcituva novoto nivo.
		Application.LoadLevel (nextLevel);
	}

}
