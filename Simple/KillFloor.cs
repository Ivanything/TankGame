using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public static float floor = -40f;
    public float damage;
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
    }
    void Update()
    {
        if (transform.position.y < floor)
        {
            health.TakeDamage(damage);
        }
    }
}