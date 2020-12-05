﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public bool IsFighting = false;
    private Rigidbody2D rb;
    public bool IsWorldPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (IsWorldPlayer)
        {
            GameManager.Instance.WorldPlayer = this.gameObject;
        }

    }
    
    void FixedUpdate()
    {
        if (!IsFighting)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

            float moveVertical = Input.GetAxisRaw("Vertical") * speed;

            rb.velocity = new Vector2(moveHorizontal, moveVertical);
        }
        
    }
}
