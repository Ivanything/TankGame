using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    protected Pawn pawn;
    public KeyCode lockOnInput;
    private Transform target;
    void Start()
    {
        pawn = GetComponent<Pawn>();
    }
    void Update()
    {
        if (Input.GetKeyDown(lockOnInput))
        {
            target = giveClosestTarget();
        }
        else if (Input.GetKeyUp(lockOnInput))
        {
            target = null;
        }

        if (target)
        {
            rotateTowards(target.position);
        }
    }

    public Transform giveClosestTarget()
    {
        List<Pawn> pawnList = GameManager.gm.tanks;
        float closestDistance = 1000000;
        Pawn closestPawn = pawnList[0];
        for (int i = 0; i < pawnList.Count; i++)
        {
            if (pawnList[i] == pawn) continue;// Skip the pawn if it's mine

            float dis = Vector3.Distance(transform.position, pawnList[i].transform.position);
            if (dis < closestDistance)
            {
                closestDistance = dis;
                closestPawn = pawnList[i];
            }
        }
        return closestPawn.transform;
    }

    public void rotateTowards(Vector3 pos)
    {
        if (Vector3.Angle(transform.forward, pos - transform.position) < 0.5f)
        {
            // No need to rotate since already facing correct direction
            return;
        }

        if (AIController.isPositionOnRightSide(transform, pos))
        {
            pawn.TurnRight();
        }
        else
        {
            pawn.TurnLeft();
        }
    }
}