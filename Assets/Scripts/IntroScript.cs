using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour {

    protected Canvas canvas;
 
	// Use this for initialization
	void Start ()
    {
        canvas = GetComponent<Canvas>();

        SetVisiableCan(false);
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canvas.enabled = !canvas.enabled;

        }  

    }

    public void SetVisiableCan(bool visiable)
    {
        canvas.enabled = visiable;

    }
}
