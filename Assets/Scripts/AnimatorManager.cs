using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    float horizontalInput;
    float minGroundNormalY;
    bool grounded;

    void Awake() 
    {
        animator = GetComponent<Animator>();
        minGroundNormalY = transform.position.y;
    }

    void FixedUpdate() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        grounded = (this.transform.position.y <= minGroundNormalY);

        if (grounded)
            return;

        if (horizontalInput != 0f)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    public void SetWin()
    {
        animator.SetBool("Win", true);
    }
}
