using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected Pawn pawn;
    void Start()
    {
        pawn = GetComponent<Pawn>();
        GameManager.gm.controllers.Add(this);
    }
    public abstract void ProcessInputs();
    public virtual void OnDestroy()
    {
        GameManager.gm.controllers.Remove(this);
    }
}