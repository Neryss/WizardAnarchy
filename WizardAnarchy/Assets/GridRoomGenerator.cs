using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRoomGenerator : MonoBehaviour
{
    private int [,] gridTiles;
    public GameObject[] roomArray;
    // Start is called before the first frame update
    void Start()
    {
        CustomGrid cgrid = new CustomGrid(5, 5, 29, 19);
        gridTiles = cgrid.GetArray();
        
        for(int x = 0; x < cgrid.GetSize("width"); x++)
        {
            for(int y = 0; y < cgrid.GetSize("height"); y++)
            {
                Debug.Log("h");
                float posX = x * 29;
                float posY = y * -19;
                Debug.Log(x + ", " + y);
                Instantiate(roomArray[0], new Vector2(posX, posY), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
