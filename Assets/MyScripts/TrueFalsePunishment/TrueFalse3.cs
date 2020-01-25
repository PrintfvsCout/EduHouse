﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrueFalse3 : MonoBehaviour
{
    public GameObject doorObject;


    protected Canvas canvas;
    protected Collision2D coll;
    private QuestionBase.Question currentQuestion;
    protected Text question;
    protected Animator animator;

    bool check = true;


    protected string[] Baza = { "Arrays have a fixed size" };

    void Start()
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

            question.text = "Don't waste your time and move it!";
            doorObject.SetActive(false);
            check = false;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points + 5);

            GameObject.Find("AnswerButtonTrueB").GetComponent<Button>().interactable = false;
            GameObject.Find("AnswerButtonFalseA").GetComponent<Button>().interactable = false;

        }

        else
        {

            question.text = "I encorage you to try again \n" + Baza[0];

            int points = 0;

            name = PlayerPrefs.GetString("Player name");
            points = PlayerPrefs.GetInt(name);
            PlayerPrefs.SetInt(name, points - 2);

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
