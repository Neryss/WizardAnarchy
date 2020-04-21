using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Camera cam;
    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("mouse pos :" + mousePos);
    }
}
