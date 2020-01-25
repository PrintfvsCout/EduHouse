using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenTrollDoor2 : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject finalDoor;


    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;


    bool check = true;


    protected string[] Baza = {"Choose the invalid identifier from the below."
            ,"To print a float value which format specifier can be used?",
        "HAS-A relationship between the classes is shown through."
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

            question.text = "Master won't be happy about this... ";
            doorObject.SetActive(false);
            finalDoor.SetActive(false);
            check = false;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points + 10);

            GameObject.Find("AnswerButtonTrollTrue2").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse24").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse12").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse22").GetComponent<Button>().interactable = false;


        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerButtonTrollTrue2").GetComponentInChildren<Text>().text = "volatile";
                GameObject.Find("AnswerButtonTrollFalse24").GetComponentInChildren<Text>().text = "Int";
                GameObject.Find("AnswerButtonTrollFalse12").GetComponentInChildren<Text>().text = "DOUBLE";
                GameObject.Find("AnswerButtonTrollFalse22").GetComponentInChildren<Text>().text = "__0__";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTrollTrue2").GetComponentInChildren<Text>().text = "%f";
                GameObject.Find("AnswerButtonTrollFalse24").GetComponentInChildren<Text>().text = "%lf";
                GameObject.Find("AnswerButtonTrollFalse12").GetComponentInChildren<Text>().text = "%Lf";
                GameObject.Find("AnswerButtonTrollFalse22").GetComponentInChildren<Text>().text = "%float";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTrollTrue2").GetComponentInChildren<Text>().text = "Container classes";
                GameObject.Find("AnswerButtonTrollFalse24").GetComponentInChildren<Text>().text = "Inheritance";
                GameObject.Find("AnswerButtonTrollFalse12").GetComponentInChildren<Text>().text = "Polymorphism";
                GameObject.Find("AnswerButtonTrollFalse22").GetComponentInChildren<Text>().text = "Functors";

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
                GameObject.Find("AnswerButtonTrollTrue2").GetComponentInChildren<Text>().text = "volatile";
                GameObject.Find("AnswerButtonTrollFalse24").GetComponentInChildren<Text>().text = "Int";
                GameObject.Find("AnswerButtonTrollFalse12").GetComponentInChildren<Text>().text = "DOUBLE";
                GameObject.Find("AnswerButtonTrollFalse22").GetComponentInChildren<Text>().text = "__0__";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTrollTrue2").GetComponentInChildren<Text>().text = "%f";
                GameObject.Find("AnswerButtonTrollFalse24").GetComponentInChildren<Text>().text = "%lf";
                GameObject.Find("AnswerButtonTrollFalse12").GetComponentInChildren<Text>().text = "%Lf";
                GameObject.Find("AnswerButtonTrollFalse22").GetComponentInChildren<Text>().text = "%float";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTrollTrue2").GetComponentInChildren<Text>().text = "Container classes";
                GameObject.Find("AnswerButtonTrollFalse24").GetComponentInChildren<Text>().text = "Inheritance";
                GameObject.Find("AnswerButtonTrollFalse12").GetComponentInChildren<Text>().text = "Polymorphism";
                GameObject.Find("AnswerButtonTrollFalse22").GetComponentInChildren<Text>().text = "Functors";

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
