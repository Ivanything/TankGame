using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUpright : MonoBehaviour
{
    public float strength;
    void Update()
    {
        Vector3 wantedForward = Vector3.Cross(transform.right, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(wantedForward, Vector3.up), Time.deltaTime * strength);
    }
}