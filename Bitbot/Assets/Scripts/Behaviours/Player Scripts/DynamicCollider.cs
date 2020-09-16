﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCollider : MonoBehaviour
{
    private PlayerMovement move;
    private BoxCollider2D bc;
    void Start()
    {
        move = GameObject.Find("Player").GetComponent<PlayerMovement>();
        bc = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        flipColliderX();
    }

    void flipColliderX()
    {
        if(move.isWallSliding)
        {
            return;
        }
        if(!move.facingLeft)
        {
            if (bc.offset.x < 0)
            {
                bc.offset = new Vector2(-bc.offset.x, bc.offset.y);
            }
        }
        if(move.facingLeft)
        {
            if (bc.offset.x > 0)
            {
                bc.offset = new Vector2(-bc.offset.x, bc.offset.y);
            }
        }
    }
}
