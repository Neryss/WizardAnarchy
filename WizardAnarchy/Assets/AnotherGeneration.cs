using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public float[][] coordArray;
    public bool stopGeneration = false;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        coordArray = InitArray(coordArray, 5, 5, 29, 19);
        PrintJaggedArray(coordArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float[][] InitArray(float[][] coordArray, int width, int height, int xRoomSize, int yRoomSize)
    {
        int x = 0;
        int y = 0;
        while(y < height)
        {
            while(x < width)
            {
                coordArray[x][y] = x * xRoomSize;
                x++;
            }
            x = 0;
            coordArray[x][y] = y * -yRoomSize;
            y++;
        }
        return(coordArray);
    }

    private void PrintJaggedArray(float[][] jaggedArray)
    {
        for(int x = 0; x < jaggedArray[x].Length; x++)
        {
            for(int y = 0; y < jaggedArray[x][y]; y++)
            {
                Debug.Log(jaggedArray[x][y]);
            }
        }
    }
}
