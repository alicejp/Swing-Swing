using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In order to update Crosshair's position with mouse's world point.
/// </summary>
public class CrosshairManager : MonoBehaviour
{
    [Tooltip("Distance between itself and the player.")]
    public float offset = 1;

    void Update()
    {
        //Target: Let player believe that their Mouse control the crosshair's position.
        //Fact: Update its position with mouse's location.

        //1. Get mouse's wolrd point.
        var mouseWorldPoint = GetMouseWorldPoint();
        //2. Get the relative rotation.
        var angle = GetRelativeRotation(mouseWorldPoint);
        //3. Use the angle result from Atan2 to update its local position.
        SetLocalPosition(angle);
    }



    /// <summary>
    /// Set its local position with offset, Mathf.Cos and Mathf.Sin value.
    /// </summary>
    void SetLocalPosition(float angle)
    {
        this.transform.localPosition = new Vector3(offset * Mathf.Cos(angle), offset * Mathf.Sin(angle));
    }


    Vector3 GetMouseWorldPoint()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
    }

    /// <summary>
    /// Calculate the distance in between mouse and it's parent position (player's position).
    /// Then use Mathf.Atan2 to get the relative rotation.
    /// </summary>
    float GetRelativeRotation(Vector3 mouseWorldPoint)
    {
        //Transform.parent is the player.
        var diff = mouseWorldPoint - transform.parent.position;

        //Atan2 reflects the result with the input's quadrant.
        //So there is no need to do extra mathematic here.
        //Document Link : https://unique-jellyfish-272.notion.site/Atan2-is-the-true-hero-in-this-class-b25445001b1941739eaad57c8944e901
        //angle can be negative.
        var angle = Mathf.Atan2(diff.y, diff.x);
        return angle;
    }
}
