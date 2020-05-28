using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject roomBuffer;
    public RoomController roomController;
    private int roomCount;
    public int maxRoom;
    
    private void Start() {
        //Spawns the first room at the generator position
        roomBuffer = GameObject.Instantiate(RandomRoomSelection(rooms), transform.position, Quaternion.identity);

        roomController = roomBuffer.GetComponent<RoomController>();
        Move();
    }

    private GameObject RandomRoomSelection(GameObject[] roomArray)
    {
        int i = Random.Range(0, roomArray.Length);
        GameObject selectedRoom = roomArray[i];

        return(selectedRoom);
    }

    private void SpawnRoom()
    {
        Instantiate(RandomRoomSelection(rooms), transform.position, Quaternion.identity);
    }

    private void Move()
    {
        
    }
}
