using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "House")
        {
            Debug.Log("Win");
            GetComponent<AnimatorManager>().SetWin();
        }
    }
}
