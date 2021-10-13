using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float lowestY = -5f;

    void Update()
    {
        if (this.transform.position.y <= lowestY)
            SceneManager.LoadScene("Game");
    }
}
