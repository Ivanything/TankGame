using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static List<Vector3> obstaclePositions = new List<Vector3>();
    public static List<float> radii = new List<float>();

    public static float OBSTACLE_AVOIDANCE_ANGLE = 60;

    public float radius;
    void Start()
    {
        Vector3 newObstaclePos = transform.position;
        newObstaclePos.y = 0;
        obstaclePositions.Add(newObstaclePos);
        
        radii.Add(radius);
    }
    public static int findObstacle(Vector3 pos, Vector3 forward, float detectDistance)
    {
        pos.y = 0;
        for (int i = 0; i < obstaclePositions.Count; i++)
        {
            if (isInDistanceWithObstacle(pos, i, detectDistance) && isObstacleInWay(pos, forward, i))
            {
                return i;
            }
        }
        return -1;
    }
    public static bool isInDistanceWithObstacle(Vector3 pos, int obstacleIndex, float detectDistance)
    {
        return Vector2.Distance(pos, obstaclePositions[obstacleIndex]) <= detectDistance + radii[obstacleIndex];
    }
    public static void goAroundObstacle(Pawn tank, int obstacleIndex)
    {
        if (obstacleIndex < 0) return;// If obstacleIndex is invalid, stop

        Vector3 currentObstaclePos = obstaclePositions[obstacleIndex];

        if (AIController.isPositionOnRightSide(tank.transform, currentObstaclePos))
        {
            tank.TurnLeft();
        }
        else
        {
            tank.TurnRight();
        }
    }
    public static bool isObstacleInWay(Transform pawn, int obstacleIndex, float destinationDistance)
    {
        if (obstacleIndex < 0) return false;
        Vector3 pawnToObstacleVector = (obstaclePositions[obstacleIndex] - pawn.position).normalized;

        if (Vector3.Distance(obstaclePositions[obstacleIndex], pawn.position) > destinationDistance)
        {
            return false;
        }

        return Vector3.Angle(pawn.forward, pawnToObstacleVector) < OBSTACLE_AVOIDANCE_ANGLE;
    }
    public static bool isObstacleInWay(Vector3 pos, Vector3 forward, int obstacleIndex)
    {
        if (obstacleIndex < 0) return false;
        Vector3 pawnToObstacleVector = (obstaclePositions[obstacleIndex] - pos).normalized;
        return Vector3.Angle(forward, pawnToObstacleVector) < OBSTACLE_AVOIDANCE_ANGLE;
    }
}