using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistEnemyController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform target;
    public float moveSpeed;
    public float aggroRange;
    private Vector2 movePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if(Vector2.Distance(target.position, transform.position) == aggroRange)
        {
            rb2D.velocity = new Vector2(0, 0);
        }
        if(Vector2.Distance(target.position, transform.position) > aggroRange)
        {
            rb2D.velocity = movePos * moveSpeed;
        }
        if(Vector2.Distance(target.position, transform.position) < aggroRange)
        {
            rb2D.velocity = -movePos * moveSpeed;
        }
    }
}
