using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightExplosion : PhysicsExplosion
{
    public float jumpForce;
    public override void HitObject(Collider c)
    {
        base.HitObject(c);
        if (c.attachedRigidbody && !c.CompareTag("Immovable"))
            c.attachedRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
