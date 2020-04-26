using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed;
    public float range;
    public Transform target;
    public Rigidbody2D slimeRB;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            SlimeMove();
        }
    }

    void FixedUpdate()
    {
        direction = target.position - transform.position;
    }

    private void SlimeMove()
    {
        if(Vector2.Distance(transform.position, target.position) >= range)
        {
            slimeRB.velocity = direction.normalized * speed;
        }
    }
}
