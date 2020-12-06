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
    private bool IsFlipped;

    public AudioClip Running;
    public AudioSource Sound;


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
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        float moveVertical = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector2(moveHorizontal, moveVertical);

        if (moveVertical > 0)
        {
            Anim.SetBool("IsGoingUp", true);
        }
        else if (moveVertical <= 0)
        {
            Anim.SetBool("IsGoingUp", false);
        }

        if (moveHorizontal < 0)
        {
            Flip();
            IsFlipped = false;
        }
        else if (moveHorizontal > 0)
        {
            Flip();
            IsFlipped = true;
        }

        // ----- Joue le son de marche si le joueur à une velocité
        if (rb.velocity != new Vector2(0, 0))
        {
            if (Sound.isPlaying == false)
            {
                PlaySound();
            }
        }


        if(rb.velocity != new Vector2(0,0) && Anim.GetBool("IsGoingUp") == false)
        {
            Anim.SetBool("Run", true);

        }
        else if(rb.velocity == new Vector2(0, 0))
        {
            Anim.SetBool("Run", false);
            StopSound();
        }
        
    }

    private void PlaySound()
    {
        Sound.PlayOneShot(Running);

    }

    private void Flip()
    {
        if (!IsFlipped)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;

        ///transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void StopSound()
    {
        Sound.Stop();
    }
}
