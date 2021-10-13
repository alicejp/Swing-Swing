using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpOffSpeed = 4f;
    public float minGroundNormalY;
    Rigidbody2D rb2D;
    float horizontalInput;
    bool grounded;
    SpriteRenderer playerSprite;

    void Awake() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        minGroundNormalY = transform.position.y;
    }

    void FixedUpdate() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            playerSprite.flipX = horizontalInput < 0f;
        }

        grounded = (this.transform.position.y <= minGroundNormalY);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2D.velocity =  new Vector2(rb2D.velocity.x, jumpOffSpeed);
        }
    }
}
