using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindTankEnemy : TankAIController, IHear
{
    private bool heardSomething = false;
    private Vector3[] patrolSpots = new Vector3[2];
    private int spotIndex;

    public float patrolDelay;
    private float d;
    public override void Start()
    {
        base.Start();
        patrolSpots[0] = transform.position;
        patrolSpots[1] = -transform.position;
        patrolSpots[1].y = patrolSpots[0].y;
    }
    void Update()
    {
        if (heardSomething)
        {
            rotateTowards(destination);
            ShootLogic();
        }
        if (!isAtDestination())
        {
            goToPosition(destination);
        }
        else
        {
            CheckPosition();
        }
    }

    public void CheckPosition()
    {
        if (d > 0)
        {
            d -= Time.deltaTime;
            return;
        }

        d = patrolDelay;

        spotIndex++;
        spotIndex %= patrolSpots.Length;
        destination = patrolSpots[spotIndex];
        heardSomething = false;
    }

    public override void goToPosition(Vector3 pos)
    {
        rotateTowards(pos);
        pawn.MoveForward();
    }

    public void iDetectHearing(Vector3 pos)
    {
        destination = pos;
        heardSomething = true;
    }
}

interface IHear
{
    void iDetectHearing(Vector3 pos);
}