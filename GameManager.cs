using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static int mapSeed;

    public GameObject playerPawn;
    public GameObject[] versusPlayerPawns;
    public GameObject[] enemyPawns;
    public int enemiesToSpawn;
    public Controller player;
    public List<Pawn> tanks = new List<Pawn>();
    public List<Controller> controllers = new List<Controller>();
    public List<AIController> aiControllers = new List<AIController>();
    public DoorScript currentDoor;
    public bool isMapOfTheDay;
    public bool twoPlayers;
    void Awake()
    {
        if (gm)
        {
            Destroy(gameObject);
            return;
        }
        gm = this;
        if (isMapOfTheDay)
            mapSeed = DateToInt(DateTime.Now.Date);
        else
            mapSeed = DateToInt(DateTime.Now);

        mapSeed *= mapSeed;
        DontDestroyOnLoad(gameObject);//
    }

    public static bool hasSpawns()
    {
        return SpawnPoint.points.Count > 0;
    }

    public IEnumerator SingleMode()
    {
        yield return new WaitUntil(hasSpawns);
        SpawnPlayer();
        SpawnEnemies(enemiesToSpawn);
        yield break;
    }

    public IEnumerator VersusMode()
    {
        yield return new WaitUntil(hasSpawns);
        SpawnPlayer(0);
        SpawnPlayer(1);
    }

    public void SpawnPlayer()
    {
        int rand = Mathf.Abs(getRandomNumber(48) % SpawnPoint.points.Count);
        GameObject newPlayer = Instantiate(playerPawn, SpawnPoint.points[rand], Quaternion.LookRotation(Vector3.forward));
        player = newPlayer.GetComponent<Controller>();
    }
    public void SpawnPlayer(Vector3 pos)
    {
        GameObject newPlayer = Instantiate(playerPawn, pos, Quaternion.LookRotation(Vector3.forward));
        player = newPlayer.GetComponent<Controller>();
    }

    public void SpawnPlayer(int num)
    {
        int rand = UnityEngine.Random.Range(0, SpawnPoint.points.Count);
        GameObject newPlayer = Instantiate(versusPlayerPawns[num], SpawnPoint.points[rand], Quaternion.LookRotation(Vector3.forward));
        VersusScript.setCharacter(newPlayer.GetComponent<Controller>(), num);
    }    

    public void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randPos = Mathf.Abs(getRandomNumber(34 + i * 2) % SpawnPoint.points.Count);
            int randEne = Mathf.Abs(getRandomNumber(19 + i * 7) % enemyPawns.Length);
            GameObject newEnemy = Instantiate(enemyPawns[randEne], SpawnPoint.points[randPos], Quaternion.LookRotation(Vector3.forward));
        }
    }

    public void PawnDied(Health h)
    {
        if (currentDoor)
        {
            currentDoor.DamageDoor();
        }
    }

    public static int getRandomNumber(int offset)
    {
        UnityEngine.Random.InitState(offset + mapSeed);
        //print((int)(UnityEngine.Random.value * 541273657));
        //print(offset + mapSeed);
        UnityEngine.Random.InitState(offset + mapSeed);
        return (int)(UnityEngine.Random.value * 541273657);
    }
    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year * 1 + dateToUse.Month * 2 + dateToUse.Day * 3 + dateToUse.Hour * 4 + dateToUse.Minute * 5 + dateToUse.Second * 6 + dateToUse.Millisecond * 7;
    }

    public void setMapOfTheDay(bool b)
    {
        isMapOfTheDay = b;
    }

    public static void Restart()
    {
        DoNewLevel(SceneManager.GetActiveScene().name, gm.twoPlayers);
        print(SpawnPoint.points.Count);
        gm.Awake();
        //gm.Start();
    }
    public static void ClearAllVariables()
    {
        Obstacle.obstaclePositions.Clear();
        Obstacle.radii.Clear();
        SafeSpot.safeSpots.Clear();
        LevelGenerator.doorDelay = 12;
        SpawnPoint.points.Clear();
        gm.tanks.Clear();
        gm.controllers.Clear();
        ForwardPointGain.began = false;
    }
    public static void DoNewLevel(string level, bool versus)
    {
        ClearAllVariables();
        SceneManager.LoadScene(level);
        if (versus)
        {
            gm.StartCoroutine(gm.VersusMode());//gm.Invoke("VersusMode", Time.deltaTime);//
        }
        else
        {
            gm.StartCoroutine(gm.SingleMode());//gm.Invoke("SingleMode", Time.deltaTime); //
        }
    }
}