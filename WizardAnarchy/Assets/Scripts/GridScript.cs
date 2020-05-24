using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid {
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public CustomGrid(int width, int height, float cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        GameObject refTile = (GameObject)Resources.Load("TestSprite");
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log(x + ", " + y);
                float posX = x * cellSize;
                float posY = y * -cellSize;

                GameObject tile = GameObject.Instantiate(refTile, new Vector2(posX, posY), Quaternion.identity);
            }
        }
        GameObject.Destroy(refTile);
    }
}
