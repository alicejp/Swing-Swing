using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public LayerMask ropeLayerMask;

    // Debug use
    public List<Transform> nodes;
    
    float ropeMaxCastDistance = 20f;
    LineRenderer lr;
    PlayerOnRopeMovement playerOnRopeMovement;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        playerOnRopeMovement = GetComponent<PlayerOnRopeMovement>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bool ishookedOn = (nodes.Count != 0);
            if (ishookedOn)
            {
                ResetAll();
                return;
            }
            
            RayCastToMousePosition();
        }
        SetRopeRenderer();
    }

    void RayCastToMousePosition()
    {
        var mouseWorldPoint =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        
        var direction = mouseWorldPoint - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, ropeMaxCastDistance, ropeLayerMask);

        if(hit.collider != null)
        {
            IsHookedHandler(hit.point);
        }
    }

    void IsHookedHandler(Vector2 hitPoint)
    {
        playerOnRopeMovement.SetIsHooked(true);

        AddNodeToList(hitPoint);
        AddSelfPositionToList();
        ActivateDistanceJoint(hitPoint);
    }

    void AddSelfPositionToList()
    {
        nodes.Add(gameObject.transform);
    }

    void AddNodeToList(Vector2 hitPoint)
    {
        GameObject emptyGo = new GameObject("rope node");
        Transform tf = emptyGo.transform;
        tf.position = hitPoint;
        nodes.Add(tf);
    }

    void ActivateDistanceJoint(Vector2 hitPoint)
    {
        GetComponent<HingeManager>().SetHingePosition(hitPoint);
    }

    void DeactivateDistanceJoint()
    {
        GetComponent<HingeManager>().SetHingeDisable();
    }

    void SetRopeRenderer()
    {
        // refresh the lr position count
        lr.positionCount = nodes.Count;
        lr.SetPositions(nodes.ConvertAll(d => d.position).ToArray());
    }

    void ResetLineRenderer()
    {
        lr.positionCount = 0;
        nodes.Clear();
    }

    void ResetAll()
    {
        ResetLineRenderer();
        playerOnRopeMovement.SetIsHooked(false);
        DeactivateDistanceJoint();
    }
}
