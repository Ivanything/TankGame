using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public TankShooter shooter;
    public override void Start()
    {
        base.Start();
    }
    void Update()
    {

    }
    public override void MoveForward()
    {
        mover.MoveVertical(moveSpeed);
    }
    public override void MoveBackward()
    {
        mover.MoveVertical(-moveSpeed);
    }
    public override void TurnLeft()
    {
        mover.Rotate(-turnSpeed);
    }
    public override void TurnRight()
    {
        mover.Rotate(turnSpeed);
    }
    public void Shoot()
    {
        shooter.Shoot();
    }
}