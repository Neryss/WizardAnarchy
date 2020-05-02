using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
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
        FollowPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCursor();
    }

    private void FollowPlayer()
    {
        center = (cursorInstance.transform.position + player.position) / 4;
        transform.position = center + offset;
    }

    private void MoveCursor()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorInstance.transform.position = mousePos + new Vector3(0f, 0f, 3);
    }
}
