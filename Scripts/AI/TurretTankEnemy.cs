using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTankEnemy : TankAIController
{
    protected VisionAI vision;
    private Animation hideAnimation;
    public float lookAngle;
    public float floorPosition;

    public override void Start()
    {
        base.Start();
        targetPawn = GameManager.gm.player.transform;
        vision = GetComponent<VisionAI>();
        hideAnimation = GetComponent<Animation>();

        Vector3 lastPos = transform.position;
        lastPos.y = floorPosition;
        transform.position = lastPos;
    }
    void Update()
    {
        if (vision.canSeeTarget())
        {
            if (isPlayerLooking())
            {
                hideAnimation.Play();
            }
            rotateTowards(targetPawn.position);
            destination = targetPawn.position;
            ShootLogic();
        }
        else
        {
            Idle();
        }
    }

    public bool isPlayerLooking()
    {
        return Vector3.Angle(targetPawn.forward, transform.position - targetPawn.position) < lookAngle;
    }

    void Idle()
    {
        pawn.TurnLeft();
    }

    public override void goToPosition(Vector3 pos)
    {
        return;//Turret cannot move
    }
}