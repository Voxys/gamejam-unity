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
        //speed = 5f;
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        float moveVertical = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector2(moveHorizontal, moveVertical);
    }
    /*
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        RB2D.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
