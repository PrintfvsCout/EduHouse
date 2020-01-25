using UnityEngine;
using System.Collections;

public class NextLevelBranch : MonoBehaviour
{

    // Koga nekoe telo ke stapne vrz trigger kolajderot.
    void OnTriggerEnter2D(Collider2D other)
    {
        int points = 0;
        string name;
        name = PlayerPrefs.GetString("Player name");
        points = PlayerPrefs.GetInt(name);
        Debug.Log(points);

        if (points < 25)
        {
            int nextLevel = Application.loadedLevel + 1;
            // Ako sme na posledno nivo premini na prvo.
            if (nextLevel >= Application.levelCount)
            {
                nextLevel = 0;
            }
            // Se vcituva novoto nivo.
            Application.LoadLevel(nextLevel);

        }
        else
        {
            // Racuname koe e sledno nivo.
            int nextLevel = Application.loadedLevel + 2;
            // Ako sme na posledno nivo premini na prvo.
            if (nextLevel >= Application.levelCount)
            {
                nextLevel = 0;
            }
            // Se vcituva novoto nivo.
            Application.LoadLevel(nextLevel);
        }
    }

}
