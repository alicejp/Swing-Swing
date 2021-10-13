using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpToPlayer : MonoBehaviour
{
    public GameObject player;
    public float cameraDepth = -10f;
    public float speed;
    public float minX, minY, maxX, maxY;

    void LateUpdate()
    {
        var newPosition = Vector3.Lerp(this.transform.position, player.transform.position, Time.deltaTime * speed);
        var x = Mathf.Clamp(newPosition.x, minX, maxX);
        var y = Mathf.Clamp(newPosition.y, minY, maxY);
        this.transform.position = new Vector3(x, y, cameraDepth);
    }
}
