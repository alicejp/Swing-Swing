using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpOffSpeed = 4f;
    public AudioClip jumpClip;
    public float minVelocityY = 0f;

    [Range(0, 1)] public  float jumpVolumeScale = 0.7f;

    AudioSource audioSource;
    Rigidbody2D rb2D;
    float horizontalInput;
    bool isGrounded;
    SpriteRenderer playerSprite;
    
    void Awake() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        
    }

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            playerSprite.flipX = horizontalInput < 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.velocity =  new Vector2(rb2D.velocity.x, jumpOffSpeed);
            audioSource.PlayOneShot(jumpClip, jumpVolumeScale);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
