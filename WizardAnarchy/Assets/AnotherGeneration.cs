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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float[][] InitRooms(int width, int height, int xRoomSize, int yRoomSize)
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                coordArray[x][y] = y;
            }
            coordArray[x][y] = x;
        }
        return(coordArray);
    }
}
