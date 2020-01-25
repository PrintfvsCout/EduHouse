using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenTrollDoor : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject finalDoor;


    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;


    bool check = true;


    protected string[] Baza = {"Which of the following property of Array class in C# checks whether the Array has a fixed size?"
            ,"If I am !true then I am ___.",
        "When a programmer writes a program, the code is known as __________."
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

            question.text = "Rammin Dammin ughhhhhh ok go on... ";
            doorObject.SetActive(false);
            finalDoor.SetActive(false);
            check = false;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points + 10);

            GameObject.Find("AnswerButtonTrollTrue").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse1").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse2").GetComponent<Button>().interactable = false;


        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerButtonTrollTrue").GetComponentInChildren<Text>().text = "IsFixedSize";
                GameObject.Find("AnswerButtonTrollFalse").GetComponentInChildren<Text>().text = "IsStatic";
                GameObject.Find("AnswerButtonTrollFalse1").GetComponentInChildren<Text>().text = "Length";
                GameObject.Find("AnswerButtonTrollFalse2").GetComponentInChildren<Text>().text = "None of these";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTrollTrue").GetComponentInChildren<Text>().text = "False";
                GameObject.Find("AnswerButtonTrollFalse").GetComponentInChildren<Text>().text = "Not feeling good";
                GameObject.Find("AnswerButtonTrollFalse1").GetComponentInChildren<Text>().text = "True";
                GameObject.Find("AnswerButtonTrollFalse2").GetComponentInChildren<Text>().text = "Depressed";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTrollTrue").GetComponentInChildren<Text>().text = "Source code";
                GameObject.Find("AnswerButtonTrollFalse").GetComponentInChildren<Text>().text = "Bad code";
                GameObject.Find("AnswerButtonTrollFalse1").GetComponentInChildren<Text>().text = "Programmer code";
                GameObject.Find("AnswerButtonTrollFalse2").GetComponentInChildren<Text>().text = "Linked code";

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
                GameObject.Find("AnswerButtonTrollTrue").GetComponentInChildren<Text>().text = "IsFixedSize";
                GameObject.Find("AnswerButtonTrollFalse").GetComponentInChildren<Text>().text = "IsStatic";
                GameObject.Find("AnswerButtonTrollFalse1").GetComponentInChildren<Text>().text = "Length";
                GameObject.Find("AnswerButtonTrollFalse2").GetComponentInChildren<Text>().text = "None of these";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTrollTrue").GetComponentInChildren<Text>().text = "False";
                GameObject.Find("AnswerButtonTrollFalse").GetComponentInChildren<Text>().text = "Not feeling good";
                GameObject.Find("AnswerButtonTrollFalse1").GetComponentInChildren<Text>().text = "True";
                GameObject.Find("AnswerButtonTrollFalse2").GetComponentInChildren<Text>().text = "Depressed";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTrollTrue").GetComponentInChildren<Text>().text = "Source code";
                GameObject.Find("AnswerButtonTrollFalse").GetComponentInChildren<Text>().text = "Bad code";
                GameObject.Find("AnswerButtonTrollFalse1").GetComponentInChildren<Text>().text = "Programmer code";
                GameObject.Find("AnswerButtonTrollFalse2").GetComponentInChildren<Text>().text = "Linked code";

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
