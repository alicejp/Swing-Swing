using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpOffSpeed = 4f;
    public float minGroundNormalY = -3f;
    Rigidbody2D rb2D;
    float horizontalInput;
    bool grounded;

    void Awake() 
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            var movement = new Vector2(horizontalInput, 0);
            rb2D.AddForce(movement * speed);
        }

        grounded = (this.transform.position.y > minGroundNormalY);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2D.velocity =  new Vector2(rb2D.velocity.x, jumpOffSpeed);
        }
    }
}
