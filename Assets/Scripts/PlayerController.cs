using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Interface between the Player and the human player controlling it. It represents the human player's will.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float HorizontalInput
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float VerticalInput
    {
        get
        {
            return Input.GetAxis("Vertical");
        }
    }
    public bool JumpBottonPressed
    {
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }

    public bool Grappling
    {
        get
        {
            return Input.GetMouseButtonDown(0);
        }
    }

    public bool UnHook
    {
        get
        {
            return Input.GetMouseButtonDown(1);
        }
    }

    public bool isGrounded;
}
