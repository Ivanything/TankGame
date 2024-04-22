using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static List<Vector3> points = new List<Vector3>();
    void Awake()
    {
        points.Add(transform.position);
        Destroy(this);
        //print(points.Count);
    }
}