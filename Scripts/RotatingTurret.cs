using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTurret : MonoBehaviour
{
    protected TankPawn pawn;
    public float shootDelay;
    float d;
    void Start()
    {
        pawn = GetComponent<TankPawn>();
        d = shootDelay;

        if (Random.Range(0, 2) == 0)
            pawn.turnSpeed *= -1;
    }
    void Update()
    {
        pawn.TurnRight();

        if (d > 0)
        {
            d -= Time.deltaTime;
            return;
        }

        pawn.Shoot();
        d = shootDelay;
    }
}