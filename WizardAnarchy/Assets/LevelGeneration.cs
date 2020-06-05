using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Vector2 worldSize = new Vector2(4, 4);
    Room[,] rooms;
    List<Vector2> takenPos = new List<Vector2>();
    int gridSizeX, gridSizeY, nbOfRooms = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRooms()
    {
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 1);    //Init at half the grid size so in the center with the room type 1 (starting room)
        takenPos.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;
    }
}
