using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRoomGenerator : MonoBehaviour
{
    private int [,] gridTiles;
    // Start is called before the first frame update
    void Start()
    {
        CustomGrid cgrid = new CustomGrid(5, 5, 29, 19);
        gridTiles = cgrid.GetArray();

        for(int x = 0; x < cgrid.GetSize("width"); x++)
        {
            for(int y = 0; y < cgrid.GetSize("Height"); y++)
            {
                Debug.Log(x + ", " + y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
