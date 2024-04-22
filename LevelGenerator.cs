using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static float generateDistance = 15;
    public static int doorDelay = 12;
    public float roomWidth;
    public int levelWidth;
    private Transform target;
    public GameObject room;
    public GameObject door;
    public Transform[] walls;
    void Start()
    {
        target = GameManager.gm.player.transform;
        Vector3 wallPos = walls[0].localPosition;
        wallPos.x = roomWidth * levelWidth + roomWidth / 2f + walls[0].localScale.x / 2f;
        walls[0].localPosition = wallPos;
        wallPos.x *= -1;
        walls[1].localPosition = wallPos;
    }
    void Update()
    {
        if (!target)
        {
            if (GameManager.gm.controllers.Count == 0) return;
            target = GameManager.gm.player.transform;
            return;
        }

        if (Time.frameCount % 2 != 0) return;

        if (Mathf.Abs(transform.position.z - target.position.z) > generateDistance) return;

        bool spawnedDoor = false;
        if (doorDelay <= 0)
        {
            spawnedDoor = true;
            SpawnDoor();
        }
        else
        {
            print("Span");
            SpawnRooms();
            doorDelay--;
        }

        Instantiate(gameObject, transform.position + Vector3.forward * roomWidth, transform.rotation);

        if (myRandomNumber(8271, transform.position.z) % 3 != 0 || spawnedDoor)
            walls[0].parent = null;
        if (myRandomNumber(2160, transform.position.z) % 3 != 0 || spawnedDoor)//Random.Range(0, 3)
            walls[1].parent = null;


        Destroy(gameObject);
    }
    void SpawnRooms()
    {
        GameObject newRoom = Instantiate(room, transform.position, transform.rotation);
        nameRoom(newRoom);
        for (int i = 1; i <= levelWidth; i++)
        {
            newRoom = Instantiate(room, transform.position + (Vector3.right * (i * roomWidth)), transform.rotation);
            nameRoom(newRoom);
        }
        for (int i = 1; i <= levelWidth; i++)
        {
            newRoom = Instantiate(room, transform.position - (Vector3.right * (i * roomWidth)), transform.rotation);
            nameRoom(newRoom);
        }
    }
    void nameRoom(GameObject g)
    {
        g.name = "Room (" + g.transform.position.x + ", " + g.transform.position.z + ")";
    }
    void SpawnDoor()
    {
        doorDelay = Mathf.Abs(myRandomNumber(7571, transform.position.z) % 16) + 10;//Random.Range(10, 25);
        Instantiate(door, transform.position, transform.rotation);
    }
    public static int myRandomNumber(int offset, float pos)
    {
        return GameManager.getRandomNumber(offset - (int)(pos * pos));
    }
}