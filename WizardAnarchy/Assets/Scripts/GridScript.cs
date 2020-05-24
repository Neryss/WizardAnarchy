using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript {
    private int width;
    private int height;
    private int[,] gridArray;

    public void Grid(int width, int height) {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];
    }
}
