﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    private GameObject roomBuffer;
    private RoomController roomController;
    private bool [] isVisited;
    private int roomCount;
    public int maxRoom;
    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    private int direction;
    private float timeBtwSpawn;
    public float maxTimeBtwSpawn = 0.25f;
    private bool randomRoom;
    private bool stopGeneration;
    private Vector2 tempPos;
    //Need to incorporate boundaries (Squate shape maybe)
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
            if(direction == 1 || direction == 2) //Move LEFT
            {
                posX = transform.position.x - 29f;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY); 
            }
            else if(direction == 3 || direction == 4) //Move RIGHT
            {
                posX = transform.position.x + 29f;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
            }
            else if(direction == 5 || direction == 6) //Move DOWN
            {
                posX = transform.position.x;
                posY = transform.position.y - 19f;
                transform.position = new Vector2(posX, posY);
            }

            //Log the simplified coordinates of the rooms so I can test with the new limiter
            int xCount = (int)posX / 29;
            int yCount = (int)posY / 19;
            Debug.Log(xCount + ", " + yCount);

            if(xCount)
            //Save last coordinates
            if(CheckOverlap())
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

    private bool CheckOverlap()
    {
        Collider2D[] checkBox = Physics2D.OverlapBoxAll(transform.position, new Vector2(27f, 18f), 0f);     //needed to tweak it down so it doesn't fuck the left position
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
