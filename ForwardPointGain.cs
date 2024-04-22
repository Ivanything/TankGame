using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPointGain : MonoBehaviour
{
    private static int lastZ;
    public float floorY;
    private Transform scorer;
    public static bool began = false;
    void Update()
    {
        if (!scorer)
        {
            scorer = GameManager.gm.player.transform;
            if (scorer && !began)
            {
                lastZ = (int)scorer.position.z;
                began = true;
                print("hi");
            }
            return;
        }
        if (transform.position.z > lastZ + 1)
        {
            ScoreScript.addScore(getAddedScore());
            lastZ = (int)scorer.position.z;
        }
        ScoreScript.setNumberSize(heightMultiplier());
    }
    float heightMultiplier()
    {
        return Mathf.Max(1 + (scorer.position.y - floorY), 1);
    }
    int getAddedScore()
    {
        float normScore = scorer.position.z - lastZ;
        normScore *= heightMultiplier();
        return (int) normScore;
    }
}