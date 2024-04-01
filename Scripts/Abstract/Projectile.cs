using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody rb;
    public float projectileSpeed;
    public float deathTime;
    public virtual void Start()
    {
        Destroy(gameObject, deathTime);
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        detectHitObject(other);
    }
    public virtual void Update()
    {
        Move();
    }
    public abstract void Move();
    public abstract void detectHitObject(Collider other);
}