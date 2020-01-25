using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenTrollDoor1 : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject finalDoor;


    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;


    bool check = true;


    protected string[] Baza = {"By default the members of the structure are"
            ," Escape sequence character \\0 occupies __ amount of memory",
        "Which of the following preprocessor directive allows generating a level one warning from a specific location in your code in C#?"
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

            question.text = "Ooga Booga, you won't get pass the others... ";
            doorObject.SetActive(false);
            finalDoor.SetActive(false);
            check = false;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points + 10);

            GameObject.Find("AnswerButtonTrollTrue1").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse10").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse11").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonTrollFalse21").GetComponent<Button>().interactable = false;


        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerButtonTrollTrue1").GetComponentInChildren<Text>().text = "Public";
                GameObject.Find("AnswerButtonTrollFalse10").GetComponentInChildren<Text>().text = "Static";
                GameObject.Find("AnswerButtonTrollFalse11").GetComponentInChildren<Text>().text = "Protected";
                GameObject.Find("AnswerButtonTrollFalse21").GetComponentInChildren<Text>().text = "None of these";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTrollTrue1").GetComponentInChildren<Text>().text = "1 byte";
                GameObject.Find("AnswerButtonTrollFalse10").GetComponentInChildren<Text>().text = "2 bytes";
                GameObject.Find("AnswerButtonTrollFalse11").GetComponentInChildren<Text>().text = "1.5 bytes";
                GameObject.Find("AnswerButtonTrollFalse21").GetComponentInChildren<Text>().text = "7 bits";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTrollTrue1").GetComponentInChildren<Text>().text = "warning";
                GameObject.Find("AnswerButtonTrollFalse10").GetComponentInChildren<Text>().text = "region";
                GameObject.Find("AnswerButtonTrollFalse11").GetComponentInChildren<Text>().text = "line";
                GameObject.Find("AnswerButtonTrollFalse21").GetComponentInChildren<Text>().text = "error";

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
                GameObject.Find("AnswerButtonTrollTrue1").GetComponentInChildren<Text>().text = "Public";
                GameObject.Find("AnswerButtonTrollFalse10").GetComponentInChildren<Text>().text = "Static";
                GameObject.Find("AnswerButtonTrollFalse11").GetComponentInChildren<Text>().text = "Protected";
                GameObject.Find("AnswerButtonTrollFalse21").GetComponentInChildren<Text>().text = "None of these";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerButtonTrollTrue1").GetComponentInChildren<Text>().text = "1 byte";
                GameObject.Find("AnswerButtonTrollFalse10").GetComponentInChildren<Text>().text = "2 bytes";
                GameObject.Find("AnswerButtonTrollFalse11").GetComponentInChildren<Text>().text = "1.5 bytes";
                GameObject.Find("AnswerButtonTrollFalse21").GetComponentInChildren<Text>().text = "7 bits";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerButtonTrollTrue1").GetComponentInChildren<Text>().text = "warning";
                GameObject.Find("AnswerButtonTrollFalse10").GetComponentInChildren<Text>().text = "region";
                GameObject.Find("AnswerButtonTrollFalse11").GetComponentInChildren<Text>().text = "line";
                GameObject.Find("AnswerButtonTrollFalse21").GetComponentInChildren<Text>().text = "error";

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
