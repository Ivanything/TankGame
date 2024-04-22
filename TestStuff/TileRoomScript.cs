using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRoomScript : MonoBehaviour
{
    private int xPos;
    private int yPos;
    MapArray2D map;
    public void SetUpRoom(MapArray2D m, int x, int y)
    {
        map = m;
        xPos = x;
        yPos = y;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}