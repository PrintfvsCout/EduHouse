using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDialogEnemy : MonoBehaviour
{

    protected Canvas canvas;
    protected Collision2D coll;

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>(); //zima mi gi od deca
        canvas.enabled = false;

    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            canvas.enabled = true;

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
