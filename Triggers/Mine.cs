using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject explosion;
    public float damage;
    public float jump;
    public float floorPosition;
    void Start()
    {
        Vector3 lastPos = transform.position;
        lastPos.y = floorPosition;
        transform.position = lastPos;
    }
    void OnTriggerEnter(Collider other)
    {
        Health h = other.GetComponent<Health>();
        if (!h) return;
        Instantiate(explosion, transform.position, Quaternion.identity);
        other.attachedRigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
        h.TakeDamage(damage);
        Destroy(gameObject);
    }
}