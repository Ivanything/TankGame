using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsExplosion : MonoBehaviour
{
    public float radius;
    public float force;
    void Start()
    {
        Explode();
        Destroy(this);
    }
    public void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in hits)
        {
            if (!c.attachedRigidbody) continue;

            Vector3 explosionForce = (c.transform.position - transform.position).normalized * force;
            c.attachedRigidbody.AddForce(explosionForce, ForceMode.Impulse);
        }
    }
}