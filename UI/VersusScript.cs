using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VersusScript : MonoBehaviour
{
    public GameObject gameOver;
    public TextMeshProUGUI whoWinsText;
    public TextMeshProUGUI[] textScores = new TextMeshProUGUI[2];
    public int[] scores = { 3, 3 };
    public static Controller[] players = new Controller[2];
    public Animation someoneDied;
    AudioSource au;
    public string menu;
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.frameCount % 40 != 0) return;

        if (!players[0])
        {
            scores[0]--;
            CheckWin(0);
        }
        else if (!players[1])
        {
            scores[1]--;
            CheckWin(1);
        }
    }

    void CheckWin(int p)
    {
        if (scores[p] > 0)
        {
            GameManager.gm.SpawnPlayer(p);
            someoneDied.Play();
            return;
        }

        gameOver.SetActive(true);
        whoWinsText.text = "PLAYER " + (Mathf.Abs(p - 1) + 1) + " WINS!";
        Destroy(this);
    }

    public static void setCharacter(Controller c, int p)
    {
        players[p] = c;
    }

    public void UpdateScore()
    {
        textScores[0].text = "" + scores[0];
        textScores[1].text = "" + scores[1];
        au.Play();
    }
    public void BackToMainMenu()
    {
        GameManager.ClearAllVariables();
        SceneManager.LoadScene(menu);
    }
}