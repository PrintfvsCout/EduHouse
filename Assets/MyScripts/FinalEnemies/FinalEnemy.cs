using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalEnemy : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject finalDoor;


    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;


    bool check = true;


    protected string[] Baza = {"#include<stdio.h> main() {for()printf(Hello);}"
            ,"#include<stdio.h> " +
            "void f(int const i)" +
            " { i=5;} " +
            "main() " +
            "{ int x = 10; f(x);}",

        " In the following code, what is 'P'? " +
            "Typedef char *charp;" +
            " const charp P;"
    };

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        question = GetComponentInChildren<Text>();



        canvas.enabled = false;
    }


    void Update()
    {


    }

    public void SetAnswer(bool answer)
    {
        if (answer == true)
        {
            int points = 0;

            question.text = "Arghh just go... ";
            doorObject.SetActive(false);
            finalDoor.SetActive(false);
            check = false;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points + 10);

            GameObject.Find("AnswerTrue").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerFalse").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerFalse1").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerFalse0").GetComponent<Button>().interactable = false;


        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerTrue").GetComponentInChildren<Text>().text = "Compile error";
                GameObject.Find("AnswerFalse").GetComponentInChildren<Text>().text = "Infinite loop";
                GameObject.Find("AnswerFalse0").GetComponentInChildren<Text>().text = "Hello once";
                GameObject.Find("AnswerFalse1").GetComponentInChildren<Text>().text = "No output";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerTrue").GetComponentInChildren<Text>().text = "Error in the statement i=5.";
                GameObject.Find("AnswerFalse").GetComponentInChildren<Text>().text = "It will compile, but no output";
                GameObject.Find("AnswerFalse0").GetComponentInChildren<Text>().text = "Error in main";
                GameObject.Find("AnswerFalse1").GetComponentInChildren<Text>().text = "None of these";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerTrue").GetComponentInChildren<Text>().text = "P is a constant";
                GameObject.Find("AnswerFalse").GetComponentInChildren<Text>().text = "P is a character type";
                GameObject.Find("AnswerFalse0").GetComponentInChildren<Text>().text = "P is a pointer";
                GameObject.Find("AnswerFalse1").GetComponentInChildren<Text>().text = "P is a refferance";

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

            int num_of_question = Random.RandomRange(0, Baza.Length); //Random.Range(0, Baza.Length);

            canvas.enabled = check;

            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerTrue").GetComponentInChildren<Text>().text = "Compile error";
                GameObject.Find("AnswerFalse").GetComponentInChildren<Text>().text = "Infinite loop";
                GameObject.Find("AnswerFalse0").GetComponentInChildren<Text>().text = "Hello once";
                GameObject.Find("AnswerFalse1").GetComponentInChildren<Text>().text = "No output";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerTrue").GetComponentInChildren<Text>().text = "Error in the statement i=5";
                GameObject.Find("AnswerFalse").GetComponentInChildren<Text>().text = "It will compile, but no output";
                GameObject.Find("AnswerFalse0").GetComponentInChildren<Text>().text = "Error in main";
                GameObject.Find("AnswerFalse1").GetComponentInChildren<Text>().text = "None of these";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerTrue").GetComponentInChildren<Text>().text = "P is a constant";
                GameObject.Find("AnswerFalse").GetComponentInChildren<Text>().text = "P is a character type";
                GameObject.Find("AnswerFalse0").GetComponentInChildren<Text>().text = "P is a pointer";
                GameObject.Find("AnswerFalse1").GetComponentInChildren<Text>().text = "P is a refferance";

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
