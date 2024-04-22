using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRunner : AIController, IHear
{
    public float scaredDistance;
    public Transform model;
    public float rollSpeed;

    public override void Start()
    {
        base.Start();
        targetPawn = GameManager.gm.player.transform;

        destination = transform.position;
    }
    void Update()
    {
        if (playerIsClose(transform.position))
            destination = findSafeSpot(targetPawn.position);

        if (!isAtDestination())
        {
            goToPosition(destination);
        }
        else
        {
            Idle();
        }
    }

    public bool playerIsClose(Vector3 pos)
    {
        return targetPawn && Vector3.Distance(pos, targetPawn.position) < scaredDistance;
    }

    public Vector3 findSafeSpot(Vector3 scaredOf)
    {
        Vector3 selfToScaredVector = (scaredOf - transform.position).normalized;
        for (int i = 0; i < SafeSpot.safeSpots.Count; i++)
        {
            Vector3 spot = SafeSpot.safeSpots[i];
            Vector3 selfToSafeVector = (spot - transform.position).normalized;
            if (Vector3.Angle(selfToScaredVector, selfToSafeVector) > 75 && !playerIsClose(spot))
            {
                return spot;
            }
        }
        return SafeSpot.safeSpots[Random.Range(0, SafeSpot.safeSpots.Count)];
    }

    public void Idle()
    {
        pawn.TurnLeft();
        model.localRotation = Quaternion.Euler(Vector3.zero);
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
        model.Rotate(rollSpeed * Time.deltaTime * 90, 0, 0);
    }

    public void iDetectHearing(Vector3 pos)
    {
        destination = findSafeSpot(pos);
    }

    protected override void OnDestroy()
    {
        if (!targetPawn)
        {
            if (GameManager.gm.player)
                targetPawn = GameManager.gm.player.transform;
            if (!targetPawn) return;
        }
        targetPawn.GetComponent<TankPawn>().addedSpeed += 3;
    }
}