using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    float waitTime = 2.0f;
    AudioSource audioSource;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator WaitAndReloadGameScene(AudioClip clip, float volumeScale)
    {
        audioSource.PlayOneShot(clip, volumeScale);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Game");
    }
}
