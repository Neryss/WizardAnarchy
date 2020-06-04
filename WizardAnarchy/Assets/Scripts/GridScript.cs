using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid {
    private int width;
    private int height;
    //Added size instead of cellsize so I can get rectangular grid
    private int xSize;
    private int ySize;
    private float cellSize;
    private int[,] gridArray;

    public CustomGrid(int width, int height, float cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        //GameObject refTile = (GameObject)Resources.Load("Room_1");
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log(x + ", " + y);
                float posX = x * cellSize;
                float posY = y * -cellSize;

                //GameObject tile = GameObject.Instantiate(refTile, new Vector2(posX, posY), Quaternion.identity);
            }
        }
    }

    public CustomGrid(int width, int height, float cellSize, GameObject[] rooms) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject roomInstance = RandomRoomSelection(rooms);
                Debug.Log(x + ", " + y);
                float posX = x * cellSize;
                float posY = y * -cellSize;

                GameObject room = GameObject.Instantiate(roomInstance, new Vector2(posX, posY), Quaternion.identity);
            }
        }
    }

    public CustomGrid(int width, int height, int xSize, int ySize) {
        this.width = width;
        this.height = height;
        this.xSize = xSize;
        this.ySize = ySize;

        gridArray = new int[width, height];
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                float posX = x * xSize;
                float posY = y * -ySize;
            }
        }
    }

    private GameObject RandomRoomSelection(GameObject[] rooms)
    {
        int randomNb = Random.Range(0, rooms.Length);
        return(rooms[randomNb]);
    }

    public int[,] GetArray()
    {
        return(this.gridArray);
    }

    public int GetSize(string axis)
    {
        if(axis.Equals("width"))
        {
            return(this.width);
        }
        else if(axis.Equals("height"))
        {
            return(this.height);
        }
        else
        {
            return(0);
        }
    }
}
