using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    private GameObject roomBuffer;
    private bool[] isVisited;
    private int roomCount;
    public int maxRoom;
    public int minX;
    public int maxX;
    public int xMoveAmount;
    public int yMoveAmount;
    //public int minY;
    private int direction;
    private float timeBtwSpawn;
    public float maxTimeBtwSpawn = 0.25f;
    private bool randomRoom;
    public bool stopGeneration;
    private Vector2 tempPos;
    //Need to incorporate boundaries (Squate shape maybe)
    private void Start()
    {

        //Spawns the first room at the generator position
        //roomBuffer = GameObject.Instantiate(RandomRoomSelection(rooms), transform.position, Quaternion.identity);

        direction = Random.Range(1, 7);
        //I'll take care of the condition for spawning later
        //roomController = roomBuffer.GetComponent<RoomController>();
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0 && stopGeneration == false)
        {
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

        return (selectedRoom);
    }

    private void SpawnRoom()
    {
        if (randomRoom)
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
        if (roomCount <= maxRoom)
        {
            tempPos = transform.position;
            float posX = transform.position.x;
            float posY = transform.position.y;
            //Log the simplified coordinates of the rooms so I can test with the new limiter
            int xCount = (int)posX / 29;
            int yCount = (int)posY / 19;
             Debug.Log(xCount + ", " + yCount);
            if (direction == 1 || direction == 2) //Move LEFT
            {
                if(xCount < minX)
                {
                    direction = 5;
                }
                else
                {
                    transform.position = new Vector2(posX - 29f, posY);
                }    
            }
            else if (direction == 3 || direction == 4) //Move RIGHT
            {
                if(xCount > maxX)
                {
                    direction = 5;
                }
                else
                {
                    transform.position = new Vector2(posX + 29f, posY);
                }
            }
            else if (direction == 5 || direction == 6) //Move DOWN
            {
                transform.position = new Vector2(posX, posY - 19f);     //Can add a boundary for the Y axis, doesn't seem to need that for now;
            }
            //Save last coordinates
            if (CheckOverlap())
            {
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

    private void MoveInStart()
    {
        while(roomCount < maxRoom)
        {

        }
    }

    private bool CheckOverlap()
    {
        Collider2D[] checkBox = Physics2D.OverlapBoxAll(transform.position, new Vector2(27f, 18f), 0f);     //needed to tweak it down so it doesn't fuck the left position
        if (checkBox.Length > 0)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }
}
