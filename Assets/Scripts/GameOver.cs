using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float lowestY = -5f;
    public AudioClip clip;
    [Range(0, 1)] public float volumeScale = 0.5f;

    void Update()
    {
        if (this.transform.position.y <= lowestY)
        {
            LoadScene ls = GetComponent<LoadScene>();
            StartCoroutine(ls.WaitAndReloadGameScene(clip, volumeScale));
        }
    }
}
