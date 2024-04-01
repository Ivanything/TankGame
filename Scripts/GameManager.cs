using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public GameManager gm;
    public GameObject playerPawn;
    public GameObject enemyPawn;
    public Transform[] spawnPoints;
    public List<Pawn> players = new List<Pawn>();
    public List<Controller> controllers = new List<Controller>();
    void Awake()
    {
        if (gm)
        {
            Destroy(gameObject);
            return;
        }
        gm = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        SpawnPlayer();
        SpawnEnemies(3);
    }
    public void SpawnPlayer()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        GameObject newPlayer = Instantiate(playerPawn, spawnPoints[rand].position, spawnPoints[rand].rotation);
        players.Add(newPlayer.GetComponent<Pawn>());
        controllers.Add(newPlayer.GetComponent<Controller>());
    }
    public void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int rand = Random.Range(0, spawnPoints.Length);
            GameObject newPlayer = Instantiate(enemyPawn, spawnPoints[rand].position, spawnPoints[rand].rotation);
            players.Add(newPlayer.GetComponent<Pawn>());
        }
    }
}