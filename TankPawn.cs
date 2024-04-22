using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public Shooter shooter;
    private Shooter defaultShooter;
    public float addedSpeed;
    public override void Start()
    {
        base.Start();
        defaultShooter = shooter;
    }
    void Update()
    {
        if (addedSpeed > 0)
        {
            addedSpeed -= Time.deltaTime;
            addedSpeed = Mathf.Max(addedSpeed, 0);
        }
    }
    public override void MoveForward()
    {
        mover.MoveVertical(moveSpeed + addedSpeed);
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
        if (!shooter)
        {
            shooter = defaultShooter;
        }
        shooter.Shoot();
    }
    public void ChangeShooter(Shooter newShooter)
    {
        shooter = newShooter;
    }
}