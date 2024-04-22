using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public static int lives = 3;
    public string menu;
    public GameObject screen;
    public TextMeshProUGUI livesText;
    void Start()
    {
        lives = 3;
    }
    void Update()
    {
        if (Time.frameCount % 25 != 0) return;

        screen.SetActive(!GameManager.gm.player);
        livesText.text = "LIVES: " + lives;
    }
    public void ResetLevel()
    {
        BackToMainMenu();
        GameManager.Restart();
    }
    public void BackToMainMenu()
    {
        GameManager.ClearAllVariables();
        SceneManager.LoadScene(menu);
    }
    public void RespawnPlayer()
    {
        if (lives <= 0)
        {
            BackToMainMenu();
            return;
        }
        if (DoorScript.lastDoor)
        {
            GameManager.gm.SpawnPlayer(DoorScript.lastDoor.position + Vector3.up * 2);
        }
        else
        {
            GameManager.gm.SpawnPlayer();
        }
        lives--;
        screen.SetActive(false);
    }
}