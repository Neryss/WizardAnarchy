using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    
    private void Awake() {
        InitFirstRoom();
    }

    private GameObject RandomRoomSelection(GameObject[] roomArray)
    {
        int i = Random.Range(0, roomArray.Length);
        GameObject selectedRoom = roomArray[i];

        return(selectedRoom);
    }

    private void InitFirstRoom()
    {
        Instantiate(RandomRoomSelection(rooms), transform.position, Quaternion.identity);
    }
}
