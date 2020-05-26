using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;
    public float cellSize;
    public GameObject[] rooms;
    void Start()
    {
        //CustomGrid cGrid = new CustomGrid(gridWidth, gridHeight, cellSize, rooms);
        RandomRoomGeneration randomGen = new RandomRoomGeneration(gridWidth, gridHeight, cellSize, rooms);
    }
}
