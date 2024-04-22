using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    protected Mover mover;
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        GameManager.gm.tanks.Add(this);
    }
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void TurnLeft();
    public abstract void TurnRight();
    public virtual void OnDestroy()
    {
        GameManager.gm.tanks.Remove(this);
    }
}