using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpOffSpeed = 4f;
    public AudioClip jumpClip;
    public float minVelocityY = 0f;

    [Range(0, 1)] public float jumpVolumeScale = 0.7f;

    AudioSource audioSource;
    Rigidbody2D rb2D;
    
    SpriteRenderer playerSprite;
    PlayerController playerController;

    bool isGrounded;

    void Awake() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        // Turn right and left
        if (playerController.HorizontalInput != 0f)
        {
            playerSprite.flipX = playerController.HorizontalInput < 0f;
        }

        // Jump only if you are on the ground.
        if (playerController.JumpBottonPressed && isGrounded)
        {
            rb2D.velocity =  new Vector2(rb2D.velocity.x, jumpOffSpeed);
            audioSource.PlayOneShot(jumpClip, jumpVolumeScale);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            SetIsGrounded(true);
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            SetIsGrounded(false);
        }
    }

    void SetIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
        playerController.isGrounded = isGrounded;
    }
}
