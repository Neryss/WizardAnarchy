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
        coordArray = InitArray(gridWitdh, gridHeight);
        PrintJaggedArray(coordArray, gridWitdh, gridHeight);
        if (coordArray == null)
        {
            Debug.Log("CoordArray is empty");
        }
        else
        {
            Debug.Log(GetJaggedArrayLength(coordArray));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float[][] InitArray(int width, int height)
    {
        float[][] tempArray;
        //allocate the needed nb of rows
        tempArray = new float[height][];
        //then loop through the rows and allocate the needed number of cols for each one
        for(int i = 0; i < height; i++)
        {
            tempArray[i] = new float[width];
        }
        return (tempArray);
    }

    private void PopulateJaggedArray(float[][] jaggedArray, int roomSizeX, int roomSizeY)
    {
        for(int i = 0; i < this.gridHeight; i++)
        {
            for(int j = 0; j < this.gridWitdh; j++)
            {
                jaggedArray[i][j] = i;
            }
        }
    }

    private void PrintJaggedArray(float[][] jaggedArray, int width, int height)
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Debug.Log("Coords are: " + jaggedArray[i][j]);
            }
        }
    }

    private int[] GetJaggedArrayLength(float[][] jaggedArray)
    {
        int[] length = new int[jaggedArray.Length];
        if (jaggedArray != null)
        {
            for (int i = 0; i < jaggedArray[i].Length; i++)
            {
                //length[i] = jaggedArray[i].Length;
                Debug.Log("length of column " + i + ": " + jaggedArray[i].Length);
            }
            return (length);
        }
        else
        {
            Debug.Log("Array was null");
            return(null);
        }
    }
}
