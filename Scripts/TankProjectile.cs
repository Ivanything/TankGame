using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankProjectile : Projectile
{
    public float damage;
    public GameObject explosion;
    public override void Move()
    {
        rb.MovePosition(rb.position + transform.forward * projectileSpeed * Time.deltaTime);
    }
    public override void detectHitObject(Collider hitCollider)
    {
        IDamageable damageable = hitCollider.GetComponent<IDamageable>();
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (damageable == null)
        {
            Destroy(gameObject);
            return;
        }
        damageable.iDamage(damage);
        Destroy(gameObject);
    }
}