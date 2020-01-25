using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNameAndScore : MonoBehaviour
{

    protected Text players;
    protected string test;
    protected int score;
    protected string[] names = new string[100];

    protected string diplayscore;
	
	void Start ()
    {

        SortedList<int,string> socreboard = new SortedList<int,string>() ;

        players = GetComponent<Text>();


        test = PlayerPrefs.GetString("Player name");
        score = PlayerPrefs.GetInt(test);


        if (test == "")
        {
            players.text = "No name";
        }
        else
        {
            players.text = test + "\b                                                 "+ score.ToString();
        }
        
	}

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        players.text = "No players";
    }

    
	
	
}
