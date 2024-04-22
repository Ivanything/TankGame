using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public abstract void collect(Collider collector);
    public abstract bool isValidCollector(Collider collector);
    void OnTriggerEnter(Collider other)
    {
        if (isValidCollector(other))
        {
            collect(other);
        }
    }
}