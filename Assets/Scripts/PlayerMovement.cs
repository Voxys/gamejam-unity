using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public bool IsFighting = false;
    private Rigidbody2D rb;
    public bool IsWorldPlayer = false;
    public Animator Anim;
    private AudioSource Sound;

    void Start()
    {
        Sound = GetComponent<AudioSource>();
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

        if(rb.velocity != new Vector2(0,0))
        {
            PlaySound();
            Debug.Log("Running");
        }
        else if(rb.velocity == new Vector2(0, 0))
        {
            StopSound();
            Debug.Log("not running");
        }
        
    }

    private void PlaySound()
    {
        Sound.Play();
    }

    private void StopSound()
    {
        Sound.Stop();
    }
}
