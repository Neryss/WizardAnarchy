using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject roomBuffer;
    public RoomController roomController;
    private bool [] isVisited;
    private int roomCount;
    public int maxRoom;
    public int direction;
    private float timeBtwSpawn;
    public float maxTimeBtwSpawn = 0.25f;
    public bool randomRoom;
    private bool stopGeneration;
    private Vector2 tempPos;
    
    private void Start() {
        //Spawns the first room at the generator position
        //roomBuffer = GameObject.Instantiate(RandomRoomSelection(rooms), transform.position, Quaternion.identity);

        direction = Random.Range(1, 7);
        //I'll take care of the condition for spawning later
        //roomController = roomBuffer.GetComponent<RoomController>();
    }

    private void Update() {
        if(timeBtwSpawn <= 0 && stopGeneration == false)
        {
            roomBuffer = RandomRoomSelection(rooms);
            timeBtwSpawn = maxTimeBtwSpawn;
            Move();
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    private GameObject RandomRoomSelection(GameObject[] roomArray)
    {
        int i = Random.Range(0, roomArray.Length);
        GameObject selectedRoom = roomArray[i];

        return(selectedRoom);
    }

    private void SpawnRoom()
    {
        if(randomRoom)
        {
            Instantiate(RandomRoomSelection(rooms), transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(rooms[0], transform.position, Quaternion.identity);
        }
    }

    private void Move()
    {
        if(roomCount <= maxRoom)
        {
            tempPos = transform.position;
           // Debug.Log("Random direction is" + direction);
            float posX = 0;
            float posY = 0;
            if(direction == 1 || direction == 2) //Move LEFT ! 
            {
                Debug.Log("Left");
                Debug.Log(transform.position + " Actual position");
                posX = transform.position.x - 29f;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY); 
            }
            else if(direction == 3 || direction == 4) //Move RIGHT !
            {
                Debug.Log("Actual right position" + transform.position);
                posX = transform.position.x + 29f;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
            }
            else if(direction == 5 || direction == 6) //Move DOWN !
            {
                posX = transform.position.x;
                posY = transform.position.y - 19f;
                transform.position = new Vector2(posX, posY);
            }

            //Save last coordinates
            if(CheckOverlap())
            {
                Debug.Log("Overlapping");
                transform.position = tempPos;
                direction = Random.Range(1, 7);
                Move();
            }
            else
            {
                roomCount++;
                SpawnRoom();
                direction = Random.Range(1, 7);
            }  
        }
        else
        {
            stopGeneration = true;
        }
    }

    private bool CheckOverlap()
    {
        Collider2D[] checkBox = Physics2D.OverlapBoxAll(transform.position, new Vector2(29, 19), 0f);
        if(checkBox.Length > 0)
        {
            return(true);
        }
        else
        {
            return(false);
        }
    }
}
