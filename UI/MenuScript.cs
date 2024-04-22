using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string mainGame;
    public string versus;
    public AudioMixer mixer;
    public Toggle togo;
    public static float lowestVolume = -39;
    void Start()
    {
        togo.isOn = GameManager.gm.isMapOfTheDay;
    }
    public void StartMainGame()
    {
        GameManager.gm.twoPlayers = false;
        GameManager.DoNewLevel(mainGame, false);
    }
    public void StartVersus()
    {
        GameManager.gm.twoPlayers = true;
        GameManager.DoNewLevel(versus, true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void changeSFXVolume(float val)
    {
        if (val <= lowestVolume)
            val = -100;
        mixer.SetFloat("SFXVolume", val);
    }
    public void changeMusicVolume(float val)
    {
        if (val <= lowestVolume)
            val = -100;
        mixer.SetFloat("MusicVolume", val);
    }
}