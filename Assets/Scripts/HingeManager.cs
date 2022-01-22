using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use DistanceJoint to represent the hinge's magic.
/// </summary>
public class HingeManager : MonoBehaviour
{
    // A hinge is to connect two parts together.
    public GameObject hinge;

    SpriteRenderer hingeSprite;
    DistanceJoint2D dj2D;
    Vector2 hingePosition;
    float climbSpeed = 3f;

    void Awake() 
    {
        dj2D = GetComponent<DistanceJoint2D>();
        dj2D.enabled = false;
        hingeSprite = hinge.GetComponent<SpriteRenderer>();
    }

    public void SetHingePosition(Vector2 position)
    {
        this.hingePosition = position;
        hinge.transform.position = position;
        dj2D.distance = Vector2.Distance(transform.position, position);
        dj2D.enabled = true;
        hingeSprite.enabled = true;
    }

    public void SetHingeDisable()
    {
        dj2D.enabled = false;
        hingeSprite.enabled = false;
    }

    public void ShortenDistance(float verticalInput)
    {
        if (verticalInput >= 1f)
        {
            //Climb up
            dj2D.distance -= climbSpeed * Time.deltaTime;
        }
        else if (verticalInput < 0f)
        {
            //Climb down
            dj2D.distance += climbSpeed * Time.deltaTime;
        }
    }

    void Update()
    {
        hinge.transform.position = hingePosition;
    }
}
