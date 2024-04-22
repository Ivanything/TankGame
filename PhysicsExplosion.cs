using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsExplosion : MonoBehaviour
{
    public float radius;
    public float force;
    public virtual void Start()
    {
        Explode();
        Destroy(this);
    }
    public void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in hits)
        {
            HitObject(c);
        }
    }
    public virtual void HitObject(Collider c)
    {
        MakeSound(c);
        if (!c.attachedRigidbody || c.CompareTag("Immovable")) return;
        Vector3 explosionForce = (c.transform.position - transform.position).normalized * force;
        c.attachedRigidbody.AddForce(explosionForce, ForceMode.Impulse);
    }
    public void MakeSound(Collider c)
    {
        IHear hearable = c.GetComponent<IHear>();
        if (hearable != null)
        {
            hearable.iDetectHearing(transform.position);
        }
    }
}