using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankAIController : AIController
{
    public float shootAngle;
    public float shootDelay;
    private float currentDelay;
    public override void Start()
    {
        base.Start();
        currentDelay = shootDelay;
    }
    public void ShootLogic()
    {
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
            return;
        }

        if (Vector3.Angle(transform.forward, destination - transform.position) > shootAngle)
        {
            return;
        }

        currentDelay = shootDelay;
        (pawn as TankPawn).Shoot();
    }
}