using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPickup : MonoBehaviour
{
    public GameObject pickup;
    private GameObject currentPickup;
    public float delay;
    float d;
    void Start()
    {
        currentPickup = Instantiate(pickup, transform.position, transform.rotation);
        d = delay;
    }
    void Update()
    {
        if (currentPickup) return;

        if (d > 0)
        {
            d -= Time.deltaTime;
            return;
        }

        currentPickup = Instantiate(pickup, transform.position, transform.rotation);
        d = delay;
    }
}