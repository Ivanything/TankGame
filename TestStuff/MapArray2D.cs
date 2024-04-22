using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArray2D : MonoBehaviour
{
    public int[,] mapArray = new int[10, 10];
    private TileRoomScript[,] tileArray = new TileRoomScript[10, 10];
    public float tileWidth;
    public int width = 10;
    public int height = 10;
    public GameObject[] tiles;
    void Start()
    {
        mapArray = new int[width, height];
        tileArray = new TileRoomScript[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                mapArray[x, y] = Mathf.Abs(GameManager.getRandomNumber(x + y * 12) % tiles.Length);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 tilePos = transform.position + Vector3.right * x * width + Vector3.forward * y * height;
                TileRoomScript newTile = Instantiate(tiles[mapArray[x, y]], tilePos, transform.rotation).GetComponent<TileRoomScript>();
                newTile.SetUpRoom(this, x, y);
                tileArray[x, y] = newTile;
            }
        }
    }
    public bool hasWallLeft(int x, int y)
    {
        if (x - 1 < 0)
            return true;
        return mapArray[x - 1, y] > 0;
    }
    public bool hasWallRight(int x, int y)
    {
        if (x + 1 > width)
            return true;
        return mapArray[x + 1, y] > 0;
    }
    public bool hasWallUp(int x, int y)
    {
        if (y - 1 < 0)
            return true;
        return mapArray[x, y - 1] > 0;
    }
    public bool hasWallDown(int x, int y)
    {
        if (y + 1 > height)
            return true;
        return mapArray[x, y + 1] > 0;
    }
}