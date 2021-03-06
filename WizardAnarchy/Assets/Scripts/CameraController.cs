﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float deadZone;
    public GameObject cursor;
    private GameObject cursorInstance;
    public Transform player;
    private Vector3 mousePos;
    public Vector3 offset;
    private Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cursorInstance = Instantiate(cursor, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
    }

    void FixedUpdate()
    {
        if(player)
        {
            FollowPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            MoveCursor();
        }
    }

    //also handle the transition for the camera movement
    private void FollowPlayer()
    {
        if(Vector2.Distance(player.position, mousePos) < deadZone)
        {
            transform.position = player.position + offset;
        }
        else
        {
            center = (cursorInstance.transform.position - player.position) / 5;
            transform.position = player.position + center + offset;
        }
    }

    private void MoveCursor()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorInstance.transform.position = mousePos + new Vector3(0f, 0f, 3);
    }
}
