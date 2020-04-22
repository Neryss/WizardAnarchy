using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistEnemyController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform target;
    public float moveSpeed;
    public float minRange;
    public float maxRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector2 movePos = target.position - transform.position;
        rb2D.velocity = movePos * moveSpeed;
    }
}
