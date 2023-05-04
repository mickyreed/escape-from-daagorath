using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Input")]
    float horizontalInput; //movement this frame
    float lastHorizontalInput; // movement last frame

    [Header("Basic Movement")]
    public float moveSpeed = 5f;
    float currentMove = 0f;
    bool moving = false;
    public bool facingRight = true;
    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0 // if there was movement this frame 
            && lastHorizontalInput == 0) // and there wasnt last frame
        {//then move
            moving = true;
        }

        if (horizontalInput == 0 //no movement this frame
            && lastHorizontalInput != 0) // there was movement last frame
        {// the stop
            moving = false;
        }

        if (horizontalInput > 0f && !facingRight
            || horizontalInput < 0f && facingRight)
        {
            Flip();
        }

        lastHorizontalInput = horizontalInput;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(transform.up, 180f);
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            currentMove = horizontalInput * moveSpeed;

            _rigidbody.MovePosition((Vector2)transform.position + new Vector2(currentMove * Time.deltaTime, 0f));
        }
    }
}
