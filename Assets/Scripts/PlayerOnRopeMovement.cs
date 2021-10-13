using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnRopeMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    bool isHooked;
    float thrust = 1f;
    float swingForce = 2f;
    float horizontalInput;
    float verticalInput;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetIsHooked(bool isHooked)
    {
        this.isHooked = isHooked;
        if (isHooked)
        {
            AddUpThrust();
        }
    }

    void AddUpThrust()
    {
        rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }

    void Update() {
        // Ground check, if it is not on the ground,then if there is a vertical force, the shorten the distance joint
        // Looks like the string has special thing to shorten it.
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate() 
    {
        SwingHandler();
        ShortenHingeHandler();
    }

    void SwingHandler()
    {
        if (horizontalInput != 0 && isHooked)
        {
            if (horizontalInput > 0)
            {
                rb2D.AddForce(transform.right * swingForce);
            }
            else
            {
                rb2D.AddForce(-transform.right * swingForce);
            }

            // Useful way to sort out the direction
            //Debug.DrawLine(this.transform.position, this.transform.position + this.transform.right);
        }
    }

    void ShortenHingeHandler()
    {
        if (isHooked)
        {
            GetComponent<HingeManager>().ShortenDistance(verticalInput);
        }
    }
}
