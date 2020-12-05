using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D RB2D;

    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
<<<<<<< Updated upstream
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        float moveVertical = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector2(moveHorizontal, moveVertical);
=======
        RB2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        RB2D.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
>>>>>>> Stashed changes
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
