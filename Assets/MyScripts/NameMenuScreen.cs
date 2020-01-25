using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameMenuScreen : MonoBehaviour
{
    public InputField input;


    protected string name;
    protected int counter = 0;

    public void OnSubmit()
    {
        if (input.text == "")
        {

            GameObject.Find("Message").GetComponentInChildren<Text>().text = "Enter your name or press the PLAY button to play";
        }

        else
        {
            if (counter == 0)
            {
                int i = 0;

                name = input.text;
                Debug.Log("Entered name is:" + name);

                PlayerPrefs.SetString("Player name", name);
                PlayerPrefs.SetInt(name, 0);

                counter++;

            }
            else
            {

                GameObject.Find("Error").GetComponentInChildren<Text>().text = "You can enter your name only once";

            }

        }
    }

 

  

	
}
