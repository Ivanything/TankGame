using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int score;
    public static int highscore;
    private static TextMeshProUGUI text;
    void Start()
    {
        score = 0;
        text = GetComponent<TextMeshProUGUI>();
    }
    public static void addScore(int add)
    {
        if (add == 0) return;
        score += add;
        text.text = score + "";
        if (highscore < score)
            highscore = score;
    }
    public static void setNumberSize(float s)
    {
        text.transform.localScale = Vector3.one * s;
    }
}