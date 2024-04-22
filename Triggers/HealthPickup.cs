using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float healthAmount;
    public GameObject spawnOnDeath;
    public override void collect(Collider collector)
    {
        collector.GetComponent<Health>().Heal(healthAmount);
        Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override bool isValidCollector(Collider collector)
    {
        return collector.GetComponent<Health>();
    }
}