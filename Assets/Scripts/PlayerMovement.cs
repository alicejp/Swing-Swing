using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;
    float horizontalInput;

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
    }
}
