using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        center = new Vector3((player.position.x + mousePos.x) / 2, (player.position.y + mousePos.y) / 2, 0f);
        transform.position = Vector3.Lerp(transform.position, center + offset, Time.deltaTime);
        //need to add some boundaries so the camera only follow the cursor in certain coniditions
        //also add a float smooth but i'm tired
    }
}
