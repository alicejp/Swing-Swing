using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public float offset = 1;
    public void SetPosition(float aimingRadians)
    {
        this.transform.localPosition = new Vector3(offset * Mathf.Cos(aimingRadians), offset * Mathf.Sin(aimingRadians));
    }

    void Update()
    {
        var worldPoint =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        
        var diff = worldPoint - transform.parent.position;
        var aimingRadians = Mathf.Atan2(diff.y, diff.x);

        SetPosition(aimingRadians);
    }
}
