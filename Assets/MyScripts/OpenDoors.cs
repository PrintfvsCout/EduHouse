using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenDoors : MonoBehaviour
{
    public GameObject doorObject;


    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;




    bool check = true;
   

    protected string [] Baza = {"If I wanted to print something to the console in unity, what class and method should I use?"
            ,"Unity uses _____ as a built in programming language.",
        "Unity supports a cloud based system where you can upload your projects and download them anytime."
    };

    void Start ()
    {
        canvas = GetComponentInChildren<Canvas>();
        question = GetComponentInChildren<Text>();
     
  

        canvas.enabled = false;
	}
	

   public void SetAnswer(bool answer)
    {
        if (answer == true)
        {
            int points = 0;

            question.text = "Ugh! Fine, you can leave the house, just go trough the portal and get out of my sight! ";
            doorObject.SetActive(false);
            check = false;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name,points+10);

            GameObject.Find("AnswerButtonTruee").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Button>().interactable = false;
            GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Button>().interactable = false;
        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerButtonTruee").GetComponentInChildren<Text>().text = "Debug.Log();";
                GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Text>().text = "Printf();";
                GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Text>().text = "Console.Writeln();";
                GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Text>().text = "Alt+F4";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTruee").GetComponentInChildren<Text>().text = "C#";
                GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Text>().text = "C++";
                GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Text>().text = "C--";
                GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Text>().text = "MIPS";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTruee").GetComponentInChildren<Text>().text = "Yes";
                GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Text>().text = "No";
                GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Text>().text = "Yes, but it is paid";
                GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Text>().text = "Only as an addon";

            }
            int points = 0;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points - 5);

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Koga ke se sudri so Player pojavi go prasanjeto
        if (coll.gameObject.tag == "Player")
        {

            int num_of_question = Random.RandomRange(0,Baza.Length); //Random.Range(0, Baza.Length);

            canvas.enabled = check; 

            question.text = Baza[num_of_question];
            if (num_of_question == 0)
            {
                GameObject.Find("AnswerButtonTruee").GetComponentInChildren<Text>().text = "Debug.Log();";
                GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Text>().text = "Printf();";
                GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Text>().text = "Console.Writeln();";
                GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Text>().text = "Alt+F4";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTruee").GetComponentInChildren<Text>().text = "C#";
                GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Text>().text = "C++";
                GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Text>().text = "C--";
                GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Text>().text = "MIPS";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTruee").GetComponentInChildren<Text>().text = "Yes";
                GameObject.Find("AnswerButtonFalsee").GetComponentInChildren<Text>().text = "No";
                GameObject.Find("AnswerButtonFalsee01").GetComponentInChildren<Text>().text = "Yes, but it is paid";
                GameObject.Find("AnswerButtonFalsee02").GetComponentInChildren<Text>().text = "Only as an addon";

            }


        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {

        // Koga Player ke se odaleci skri go prasanjeto
        if (coll.gameObject.tag == "Player")
        {
            canvas.enabled = false;
        }

    }

}
