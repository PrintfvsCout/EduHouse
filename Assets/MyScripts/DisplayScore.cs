using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    protected Text score;

    void Start()
    {
        int points = 0;

        score = GetComponent<Text>();

        string name = PlayerPrefs.GetString("Player name");
        points = PlayerPrefs.GetInt(name);

        if (points < 0)
        {
            PlayerPrefs.SetInt(name, 0);
            score.text = PlayerPrefs.GetInt(name).ToString();

        }
        else
        {
            score.text = PlayerPrefs.GetInt(name).ToString();
        }
     
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        score.text = "0";
    }
}
