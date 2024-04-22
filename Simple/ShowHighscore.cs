using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHighscore : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Highscore") > ScoreScript.highscore)
        {
            ScoreScript.highscore = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", ScoreScript.highscore);
        }
        GetComponent<TextMeshProUGUI>().text = "HIGHSCORE: " + ScoreScript.highscore;
        Destroy(this);
    }
}