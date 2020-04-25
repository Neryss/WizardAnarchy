using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float BASE_MOVE_SPEED;
    public Vector2 moveInput;
    public Animator animator;
    public Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this)
        {
            MovePlayer();
        }
    }

    void FixedUpdate()
    {
        if(this)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("speed", moveInput.x);
        }
    }

    private void MovePlayer()
    {
        rb2D.velocity = new Vector2(moveInput.x * BASE_MOVE_SPEED, moveInput.y * BASE_MOVE_SPEED);
    }
}
