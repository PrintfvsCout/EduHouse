using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalEnemy1 : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject finalDoor;

    public InputField input;

    protected Canvas canvas;
    protected Collision2D coll;
    protected Text question;
    protected Animator animator;
    protected string name;


    bool check = true;


    protected string[] Baza = { "Method Overloading is an example of " };

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        question = GetComponentInChildren<Text>();



        canvas.enabled = false;
    }

    public void OnSubmit()
    {

        string answer = input.text;
        if (answer.Equals("static binding") || answer.Equals("Static Binding") || answer.Equals("staticbinding"))
        {
            SetAnswer(true);
        }

        else
        {
            SetAnswer(false);
        }
    }

    protected void SetAnswer(bool answer)
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
            Debug.Log("Given 10points");



            GameObject.Find("AnswerTrue1").GetComponent<Button>().interactable = false;



        }

        else
        {
            int num_of_question = Random.RandomRange(0, Baza.Length);
            question.text = Baza[num_of_question];




            int points = 0;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points - 5);
            Debug.Log("Taken 5 points from score");

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
