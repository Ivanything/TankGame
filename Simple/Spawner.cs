using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawns;
    public int empty;
    void Start()
    {
        int rand = Mathf.Abs(LevelGenerator.myRandomNumber(29106827, transform.position.z + transform.position.x * 19) % (spawns.Length + empty));
        if (rand > empty)//Random.Range(0, spawns.Length + empty)
        {
            rand = Mathf.Abs(LevelGenerator.myRandomNumber(6917567, transform.position.z + transform.position.x * 54) % spawns.Length);
            //print(rand);
            Instantiate(spawns[rand], transform.position, transform.rotation);//Random.Range(0, spawns.Length)
        }
        Destroy(gameObject);
    }
}
