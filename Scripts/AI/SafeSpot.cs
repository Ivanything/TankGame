using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpot : MonoBehaviour
{
    public static List<Vector3> safeSpots = new List<Vector3>();
    void Start()
    {
        safeSpots.Add(transform.position);
        Destroy(gameObject);
    }
}