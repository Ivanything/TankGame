using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject playerPawn;
    public GameObject[] enemyPawns;
    public int enemiesToSpawn;
    public Transform[] spawnPoints;
    public Pawn player;
    public List<Pawn> tanks = new List<Pawn>();
    public List<Controller> controllers = new List<Controller>();
    public List<AIController> aiControllers = new List<AIController>();
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
        SpawnEnemies(enemiesToSpawn);
    }
    
    /*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Obstacle.obstaclePositions.Clear();
            Obstacle.radii.Clear();
            SafeSpot.safeSpots.Clear();
            tanks.Clear();
            controllers.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Start();
        }
    }//*/
    public void SpawnPlayer()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        GameObject newPlayer = Instantiate(playerPawn, spawnPoints[rand].position, spawnPoints[rand].rotation);
        player = newPlayer.GetComponent<Pawn>();
        tanks.Add(player);
        controllers.Add(newPlayer.GetComponent<Controller>());
    }
    public void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int rand = Random.Range(0, spawnPoints.Length);
            GameObject newEnemy = Instantiate(enemyPawns[Random.Range(0, enemyPawns.Length)], spawnPoints[rand].position, spawnPoints[rand].rotation);
            tanks.Add(newEnemy.GetComponent<Pawn>());
            aiControllers.Add(newEnemy.GetComponent<AIController>());
        }
    }
}