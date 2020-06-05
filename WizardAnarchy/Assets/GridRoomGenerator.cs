using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRoomGenerator : MonoBehaviour
{
    private int[,] gridArray;
    private Vector2[] vectorArray;
    public GameObject[] roomArray;
    // Start is called before the first frame update
    void Start()
    {
        vectorArray = InitGrid(5, 5, 29, 19);
        for(int i = 0; i < vectorArray.Length; i++)
        {
            Debug.Log("Coordinates are : " + vectorArray[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2[] InitGrid(int width, int height, int xSize, int ySize)
    {
        gridArray = new int[width, height];
        Vector2[] coordArray = new Vector2[gridArray.Length];
        int i = 0;

        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                float posX = x * xSize;
                float posY = y * -ySize;
                Vector2 posVector = new Vector2(posX, posY);
                coordArray[i] = posVector;
                i++;
            }
        }
        return(coordArray);
    }
}
