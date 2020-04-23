using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistEnemyController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform target;
    public float moveSpeed;
    public float stoppingDistance;
    public float retreatDistance;
    private Vector2 movePos;
    private float moveTimer;
    public float startMoveTimer;

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
        movePos = target.position - transform.position;
    }

    private void MoveEnemy()
    {
        if(Vector2.Distance(target.position, transform.position) > stoppingDistance && moveTimer <= 0)
        {
            rb2D.velocity = movePos;
            moveTimer = startMoveTimer;
        }
        if(Vector2.Distance(target.position, transform.position) < stoppingDistance && Vector2.Distance(target.position, transform.position) > retreatDistance && moveTimer <= 0)
        {
            rb2D.velocity = new Vector2(0, 0);
            moveTimer = startMoveTimer;
        }
        else if(Vector2.Distance(target.position, transform.position) < retreatDistance && moveTimer <= 0)
        {
            rb2D.velocity = -movePos;
            moveTimer = startMoveTimer;
        }
        else if(moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
        }
    }
}
