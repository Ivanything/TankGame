using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected Pawn pawn;
    void Start()
    {
        pawn = GetComponent<Pawn>();
    }
    public abstract void ProcessInputs();
}