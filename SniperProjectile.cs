using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperProjectile : Projectile
{
    public GameObject explosion;
    public override void detectHitObject(Collider hitCollider)
    {
        IDamageable damageable = hitCollider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.iDamage(100);
        }
    }

    public override void Move()
    {
        rb.MovePosition(rb.position + transform.forward * projectileSpeed * Time.deltaTime);
    }
    void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}