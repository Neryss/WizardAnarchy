using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform target;
    public float moveSpeed;
    public float stoppingDistance;
    public float retreatDistance;
    private Vector2 movePos;
    private float moveTimer;
    public float startMoveTimer;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(target)
        {
            MoveEnemy();
        }
    }

    void FixedUpdate()
    {
        if(target)
        {
            movePos = target.position - transform.position;
        }
    }

    private void MoveEnemy()
    {
        if(Vector2.Distance(target.position, transform.position) > stoppingDistance)
        {
            rb2D.MovePosition(rb2D.position + movePos * moveSpeed * Time.deltaTime);
        //    moveTimer = startMoveTimer;
        }
        if(Vector2.Distance(target.position, transform.position) < stoppingDistance && Vector2.Distance(target.position, transform.position) > retreatDistance)
        {
            rb2D.position = rb2D.position;
        //    moveTimer = startMoveTimer;
        }
        else if(Vector2.Distance(target.position, transform.position) < retreatDistance)
        {
            rb2D.MovePosition(rb2D.position + movePos * -moveSpeed * Time.deltaTime);
        //    moveTimer = startMoveTimer;
        }
        //else if(moveTimer > 0)
        //{
        //    moveTimer -= Time.deltaTime;
        //}
    }
}
