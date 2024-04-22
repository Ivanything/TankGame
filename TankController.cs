using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : Controller
{
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode turnLeft;
    public KeyCode turnRight;
    public KeyCode shoot;
    void Update()
    {
        ProcessInputs();
    }
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForward))
            pawn.MoveForward();
        if (Input.GetKey(moveBackward))
            pawn.MoveBackward();

        if (Input.GetKey(turnLeft))
            pawn.TurnLeft();
        if (Input.GetKey(turnRight))
            pawn.TurnRight();



        if (Input.GetKeyDown(shoot))
            ((TankPawn)pawn).Shoot();
    }
}