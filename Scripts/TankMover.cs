using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    protected Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
    }
    public override void MoveVertical(float amount)
    {
        rb.MovePosition(rb.position + transform.forward * amount * Time.deltaTime);
    }
    public override void Rotate(float amount)
    {
        transform.Rotate(transform.up, amount * 90 * Time.deltaTime); // 90 is the multiplier because it is 1/4 of a full rotation, it counts how many 1/4 rotations per second
    }
}