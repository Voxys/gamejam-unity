using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float JumpForce;

    private Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        float moveVertical = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector2(moveHorizontal, moveVertical);
    }
}
