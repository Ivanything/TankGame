using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 target;
    public float speed;
    private float savedDistance = 0;
    float lastZ;
    void Start()
    {
        lastZ = transform.position.z;
    }
    void Update()
    {
        if (GameManager.gm.controllers.Count == 0)
        {
            if (transform.position.z > lastZ)
                transform.position -= Vector3.forward * speed * Time.deltaTime;
            return;
        }
        target = Vector3.zero;
        foreach (Controller c in GameManager.gm.controllers)
        {
            target += c.transform.position;
        }
        target /= GameManager.gm.controllers.Count;

        if (savedDistance == 0)
            savedDistance = transform.position.z - target.z;


        Vector3 newPos = transform.position;
        newPos.z = target.z + savedDistance;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);
    }
}