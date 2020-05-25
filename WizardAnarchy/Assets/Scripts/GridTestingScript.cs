using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTestingScript : MonoBehaviour
{
    public GameObject[] rooms;
    void Start()
    {
        CustomGrid cGrid = new CustomGrid(5, 5, 39, rooms);
    }
}
