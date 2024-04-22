using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : MonoBehaviour
{
    protected Pawn pawn;
    [HideInInspector]
    public Transform targetPawn;
    protected Vector3 destination;
    public float destinationDistance;
    protected int obstacleIndex = -1;
    public virtual void Start()
    {
        pawn = GetComponent<Pawn>();
        GameManager.gm.aiControllers.Add(this);
    }
    public abstract void goToPosition(Vector3 pos);
    public void rotateTowards(Vector3 pos)
    {
        if (Vector3.Angle(transform.forward, pos - transform.position) < 0.5f)
        {
            // No need to rotate since already facing correct direction
            return;
        }

        if (isPositionOnRightSide(transform, pos))
        {
            pawn.TurnRight();
        }
        else
        {
            pawn.TurnLeft();
        }
    }
    public static bool isPositionOnRightSide(Transform main, Vector3 pos)
    {
        return Vector3.Angle(main.right, pos - main.position) < 90;
    }
    public bool isAtDestination()
    {
        return Vector3.Distance(transform.position, destination) < destinationDistance;
    }
    public bool hasObstacle()
    {
        return obstacleIndex >= 0;
    }
    protected virtual void OnDestroy()
    {
        GameManager.gm.aiControllers.Remove(this);
    }

    public void ChangeTargetPawn(Transform newPawn)
    {
        targetPawn = newPawn;
    }
}