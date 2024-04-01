using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public abstract void MoveVertical(float amount);
    public abstract void Rotate(float amount);
}