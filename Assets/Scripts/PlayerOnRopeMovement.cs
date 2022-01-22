using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnRopeMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    PlayerController playerController;
    HingeManager hingeManager;
    AnimatorManager animatorManager;
    bool isHooked;
    float thrust = 1f;
    float swingForce = 40f;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        hingeManager = GetComponent<HingeManager>();
        animatorManager = GetComponent<AnimatorManager>();
    }

    public bool IsHooked
    {
        set
        {
            isHooked = value;
            if (isHooked)
            {
                AddUpThrust();
            }

            if (animatorManager.IsRunning)
            {
                animatorManager.IsRunning = false;
            }
        }

        get
        {
            return isHooked;
        }
    }

    void AddUpThrust()
    {
        rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }

    void Update() {
        
        ShortenHingeHandler();
    }

    void FixedUpdate() 
    {
        SwingHandler();
    }

    void SwingHandler()
    {
        if (playerController.HorizontalInput != 0 && isHooked)
        {
            animatorManager.IsRunning = true;

            if (playerController.HorizontalInput > 0)
            {
                rb2D.AddForce(transform.right * swingForce * Time.deltaTime);
            }
            else
            {
                rb2D.AddForce(-transform.right * swingForce * Time.deltaTime);
                
            }
            //Useful way to sort out the direction
            //Debug.DrawLine(this.transform.position, this.transform.position + this.transform.right);
        }
        else
        {
            animatorManager.IsRunning = false;
        }
    }

    void ShortenHingeHandler()
    {
        // Ground check, if it is not on the ground,then if there is a vertical force, the shorten the distance joint
        // Looks like the string has special thing to shorten it.
        bool isIntentToClimbDown = playerController.VerticalInput <= 0f;
        if (playerController.isGrounded && isIntentToClimbDown)
        {
            print("playerController.VerticalInput : " + playerController.VerticalInput);
            return;
        }else
        {
            print("playerController.isGrounded: "+ playerController.isGrounded);
            print("false , playerController.VerticalInput : " + playerController.VerticalInput);
        }
            

        if (isHooked)
        {
            hingeManager.ShortenDistance(playerController.VerticalInput);
        }
    }
}
