﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 10f;
    public float jumpForce = 7f;

    [Space]

    [Header("Booleans")]
    public bool facingRight = true;

    private Rigidbody2D rb;
    private PlayerCollision coll;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PlayerCollision>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);
        run(dir);

        flip(dir);

        if (Input.GetButtonDown("Jump"))
        {
            jump(Vector2.up);
        }

    }

    private void run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void flip(Vector2 dir)
    {
        if (!facingRight && dir.x > 0)
        {
            facingRight = true;
            sr.flipX = false;
        }
        if (facingRight && dir.x < 0)
        {
            facingRight = false;
            sr.flipX = true;
        }
    }

    private void jump(Vector2 dir)
    {
        if(!coll.onGround)
        {
            return;
        }

        rb.velocity = Vector2.zero;
        rb.velocity += dir * jumpForce;
    }
}
