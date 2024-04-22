using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public int doorHealth;
    public float downMovement;
    public TextMeshPro text;
    public AudioSource au;
    public static Transform lastDoor = null;
    void Start()
    {
        if (GameManager.gm.currentDoor)
        {
            lastDoor = GameManager.gm.currentDoor.transform.root;
        }

        GameManager.gm.currentDoor = this;
        text.text = doorHealth + "";
    }
    public void DamageDoor()
    {
        if (au) au.Play();
        transform.position -= Vector3.up * downMovement;
        doorHealth--;
        text.text = doorHealth + "";
        if (doorHealth <= 0)
        {
            lastDoor = transform.root;
            Destroy(gameObject);
        }
    }
}