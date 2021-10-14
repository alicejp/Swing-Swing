using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public AudioClip clip;
    [Range(0, 1)] public float volumeScale = 0.5f;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "House")
        {
            GetComponent<AnimatorManager>().SetWin();
            LoadScene ls = GetComponent<LoadScene>();
            StartCoroutine(ls.WaitAndReloadGameScene(clip, volumeScale));
        }
    }
}
