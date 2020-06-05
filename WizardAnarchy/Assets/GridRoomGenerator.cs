using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRoomGenerator : MonoBehaviour
{
    private int[,] gridArray;
    private Vector2[,] vectorArray;
    public GameObject[] roomArray;
    private float timeBtwSpawn;
    public float maxTimeBtwSpawn = 0.25f;
    public bool isOn = false;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            int x = 0;
            int y = 0;

            vectorArray = InitGrid(5, 5, 29, 19);
            if (timeBtwSpawn <= 0)
            {
                timeBtwSpawn = maxTimeBtwSpawn;   
                if(x < vectorArray.GetLength(0))
                {
                    if(y < vectorArray.GetLength(1))
                    {
                        Debug.Log(vectorArray[x, y]);
                    }
                    Debug.Log(vectorArray[x, y]);
                }
                else
                {
                    isOn = false;
                }
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }

    private Vector2[,] InitGrid(int width, int height, int xSize, int ySize)
    {
        float posX = 0;
        float posY = 0;

        int x = 0;
        int y = 0;
        Vector2 posVector = Vector2.zero;
        gridArray = new int[width, height];
        Vector2[,] coordArray = new Vector2[gridArray.GetLength(0), gridArray.GetLength(1)];
        for(x = 0; x < gridArray.GetLength(0); x++)
        {
            for(y = 0; y < gridArray.GetLength(1); y++)
            {
                posY = y * -ySize;
                posVector = new Vector2(posX, posY);
                coordArray[x, y] = posVector;
            }
            coordArray[x, y] = posVector;
        }
        return(coordArray);
    }
}
