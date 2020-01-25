using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalEnemy2 : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject finalDoor;


    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;


    bool check = true;


    protected string[] Baza = {"What happens when thread's yield() method is called?"
            ,"Which of the following is a marker interface?",
        "Does Java support built in data structures?"
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

            GameObject.Find("AnswerTrue2").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerFalse02").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerFalse122").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerFalse2").GetComponent<Button>().interactable = false;


        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];

            if (num_of_question == 0)
            {
                GameObject.Find("AnswerTrue2").GetComponentInChildren<Text>().text = "Thread returns to the ready state.";
                GameObject.Find("AnswerFalse2").GetComponentInChildren<Text>().text = "Thread returns to the waiting state.";
                GameObject.Find("AnswerFalse02").GetComponentInChildren<Text>().text = "Thread starts running.";
                GameObject.Find("AnswerFalse122").GetComponentInChildren<Text>().text = "Threads stop.";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerTrue2").GetComponentInChildren<Text>().text = "serializable";
                GameObject.Find("AnswerFalse2").GetComponentInChildren<Text>().text = "comparable";
                GameObject.Find("AnswerFalse02").GetComponentInChildren<Text>().text = "cloneable";
                GameObject.Find("AnswerFalse122").GetComponentInChildren<Text>().text = "notable";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerTrue2").GetComponentInChildren<Text>().text = "Yes";
                GameObject.Find("AnswerFalse2").GetComponentInChildren<Text>().text = "No";
                GameObject.Find("AnswerFalse02").GetComponentInChildren<Text>().text = "Only empty classes";
                GameObject.Find("AnswerFalse122").GetComponentInChildren<Text>().text = "None of these";

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
                GameObject.Find("AnswerTrue2").GetComponentInChildren<Text>().text = "Thread returns to the ready state.";
                GameObject.Find("AnswerFalse2").GetComponentInChildren<Text>().text = "Thread returns to the waiting state.";
                GameObject.Find("AnswerFalse02").GetComponentInChildren<Text>().text = "Thread starts running.";
                GameObject.Find("AnswerFalse122").GetComponentInChildren<Text>().text = "Threads stop.";

            }

            if (num_of_question == 1)
            {
                GameObject.Find("AnswerTrue2").GetComponentInChildren<Text>().text = "serializable";
                GameObject.Find("AnswerFalse2").GetComponentInChildren<Text>().text = "comparable";
                GameObject.Find("AnswerFalse02").GetComponentInChildren<Text>().text = "cloneable";
                GameObject.Find("AnswerFalse122").GetComponentInChildren<Text>().text = "notable";

            }

            if (num_of_question == 2)
            {
                GameObject.Find("AnswerTrue2").GetComponentInChildren<Text>().text = "Yes";
                GameObject.Find("AnswerFalse2").GetComponentInChildren<Text>().text = "No";
                GameObject.Find("AnswerFalse02").GetComponentInChildren<Text>().text = "Only empty classes";
                GameObject.Find("AnswerFalse122").GetComponentInChildren<Text>().text = "None of these";

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
