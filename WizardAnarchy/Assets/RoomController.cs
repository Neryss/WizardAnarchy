using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool leftDoor;
    public bool rightDoor;
    public bool upDoor;
    public bool downDoor;
    public Vector2 size;
    public bool GetDoor()
    {
        Debug.Log("Entered getDoor");
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

    public string WhichDoor()
    {
        if(leftDoor)
        {
            return("Left");
        }
        if(rightDoor)
        {
            return("Right");
        }
        if(upDoor)
        {
            return("Up");
        }
        if(downDoor)
        {
            return("Down");
        }
        else
        {
            return(null);
        } 
    }
}
