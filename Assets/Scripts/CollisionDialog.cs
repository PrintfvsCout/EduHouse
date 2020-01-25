using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDialog : MonoBehaviour {

   protected Canvas canvas;
    protected Collision2D coll;
    private int counter=0;
    
	

	void Start ()
    {
        canvas = GetComponentInChildren<Canvas>(); //zima mi gi od deca
        canvas.enabled = false;
		
	}
	

    void OnCollisionEnter2D(Collision2D coll)
    {
        

        if (coll.gameObject.tag == "Player")
        {
            canvas.enabled = true;
           
            

            if (counter == 0 )
            {
                //Dodadi 5 poena ako potrazi pomos
                string name;
                int points;
                name = PlayerPrefs.GetString("Player name");
                points = PlayerPrefs.GetInt(name);
                PlayerPrefs.SetInt(name, points + 5);
                Debug.Log("Given 5 points to the player");
            }

            

             if (counter > 3 )
            {
                //Zimaj po 1 poen ako trazi povise pomos
                int points = 0;
                name = PlayerPrefs.GetString("Player name");
                points = PlayerPrefs.GetInt(name);
                PlayerPrefs.SetInt(name, points - 1);
                Debug.Log("Taken 1 point from the player");

            }
              counter++;

        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            canvas.enabled = false;
        }

    }


}
