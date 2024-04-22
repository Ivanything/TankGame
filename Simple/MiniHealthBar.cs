using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniHealthBar : MonoBehaviour
{
    public Health h;
    void Update()
    {
        Vector3 scale = Vector3.one;
        scale.x = h.healthRatio();
        transform.localScale = scale;
    }
}