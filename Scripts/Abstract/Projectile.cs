using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody rb;
    public float projectileSpeed;
    public float deathTime;
    protected Controller owner;
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
    public virtual void SetOwner(Controller cont)
    {
        owner = cont;
    }
    public abstract void Move();
    public abstract void detectHitObject(Collider other);
}