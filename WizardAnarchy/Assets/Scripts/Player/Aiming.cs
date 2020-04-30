using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject crosshairInstance;
    public Camera cam;
    public Vector2 mousePos;
    public float fireAngle;
    // Start is called before the first frame update
    void Start()
    {
        crosshairInstance = Instantiate(crosshair, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        crosshairInstance.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 11);
        Vector2 lookDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        fireAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, fireAngle);
    }
}
