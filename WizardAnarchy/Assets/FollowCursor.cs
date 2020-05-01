using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public Vector3 newPos;
    public Transform player;
    public Vector3 cursorPos;
    public Vector3 offset;
    public Camera cam;
    void Start()
    {
           
    }

    void FixedUpdate()
    {
        cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
        newPos = (cursorPos - player.position) / 2;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = newPos + offset;
    }
}
