using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAI : MonoBehaviour
{
    public static byte opaqueLayer = 1 << 3;// 3 is wall layer
    public float visionAngle;
    public float visionRange;
    private AIController controller;
    void Start()
    {
        controller = GetComponent<AIController>();
    }
    public bool canSeeTarget()
    {
        return controller.targetPawn && canSeePosition(controller.targetPawn.position);
    }
    public bool canSeePosition(Vector3 pos)
    {
        Vector3 selfToTargetVector = pos - controller.transform.position;
        float distance = selfToTargetVector.magnitude;
        float angle = Vector3.Angle(controller.transform.forward, selfToTargetVector);
        if (distance > visionRange || angle > visionAngle)
        {
            return false;
        }
        return !Physics.Raycast(controller.transform.position, selfToTargetVector, distance, opaqueLayer);
    }
}