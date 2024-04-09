using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTankEnemy : TankAIController
{
    protected VisionAI vision;
    private Vector3 patrolSpot;
    public override void Start()
    {
        base.Start();
        targetPawn = GameManager.gm.player.transform;
        vision = GetComponent<VisionAI>();

        destination = transform.position;
        patrolSpot = transform.position;
    }
    void Update()
    {
        if (!isAtDestination())
        {
            goToPosition(destination);

            if (vision.canSeeTarget())
            {
                destination = targetPawn.position;
                ShootLogic();
            }
        }
        else
        {
            Idle();
            ChooseDestination();
        }
    }

    public void Idle()
    {
        pawn.TurnRight();
    }

    public void ChooseDestination()
    {
        if (vision.canSeeTarget())
        {
            destination = targetPawn.position;
        }
        else if (Vector3.Distance(destination, patrolSpot) > destinationDistance)
        {
            destination = patrolSpot;
        }
    }

    public override void goToPosition(Vector3 pos)
    {
        obstacleIndex = Obstacle.findObstacle(transform.position, transform.forward, 1);
        if (Obstacle.isObstacleInWay(transform, obstacleIndex, Vector3.Distance(transform.position, destination)))
        {
            Obstacle.goAroundObstacle(pawn, obstacleIndex);
            return;
        }

        rotateTowards(pos);
        pawn.MoveForward();
    }
}