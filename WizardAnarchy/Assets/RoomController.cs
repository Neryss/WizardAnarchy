using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController
{
    public bool leftDoor;
    public bool rightDoor;
    public bool upDoor;
    public bool downDoor;
    public Vector2 size;
    public bool GetDoor()
    {
        if(leftDoor)
        {
            Debug.Log("Left");
            return(leftDoor);
        }
        else
        {
            return(false);
        }
    }
}
