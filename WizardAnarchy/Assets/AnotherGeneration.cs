using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public float[][] coordArray;
    public bool stopGeneration = false;
    public int gridWitdh;
    public int gridHeight;
    public int roomSizeX;
    public int roomSizeY;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        coordArray = InitArray(coordArray, gridWitdh, gridHeight, roomSizeX, roomSizeY);
        if(coordArray == null)
        {
            Debug.Log("CoordArray is empty");
        }
        else
            PrintJaggedArray(coordArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float[][] InitArray(float[][] coordArray, int width, int height, int xRoomSize, int yRoomSize)
    {
        float[][] tempArray = new float[height][];
        for(int y = 0; y < height; y++)
        {
            tempArray[y] = new float[width];
        }
        return(tempArray);
    }

    private void PrintJaggedArray(float[][] jaggedArray)
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                Debug.Log(jaggedArray[i][j]);
            }
        }
    }

    private int[] GetJaggedArrayLength(float[][] jaggedArray)
    {
        int[] length = null;
        for(int i = 0; i < jaggedArray[i].Length; i++)
        {
            length[i] = jaggedArray[i].Length;
        }
        return(length);
    }
}
