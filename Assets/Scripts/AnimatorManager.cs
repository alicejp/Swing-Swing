using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// One and only one place to update the Animator object.
/// </summary>
public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    PlayerController playerController;
    private const string SPEEDKEY = "Speed";
    private const string WINKEY = "Win";

    private bool isRunning;
    public bool IsRunning
    {
        set
        {
            isRunning = value;

            if (isRunning)
            {
                animator.SetFloat(SPEEDKEY, Mathf.Abs(playerController.HorizontalInput));
            }
            else
            {
                animator.SetFloat(SPEEDKEY, 0f);
            }
        }

        get
        {
            return isRunning;
        }
    }

    void Awake() 
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    public void SetWin()
    {
        animator.SetBool(WINKEY, true);
    }
}
