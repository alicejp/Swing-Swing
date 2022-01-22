using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use RaycastHit to find the hit point, update one of the higne's position and render the rope.
/// </summary>
public class RopeManager : MonoBehaviour
{
    public LayerMask ropeLayerMask; // Filter to detect Colliders only on certain layers.
    public float ropeMaxCastDistance = 20f;
    // Debug use
    public List<Transform> nodes;
    
    LineRenderer lr;
    PlayerController playerController;
    PlayerOnRopeMovement playerOnRopeMovement;
    HingeManager hingeManager;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        playerController = GetComponent<PlayerController>();
        playerOnRopeMovement = GetComponent<PlayerOnRopeMovement>();
        hingeManager = GetComponent<HingeManager>();
    }

    void Update()
    {
        if(playerController.Grappling)
        {
            bool ishookedOn = (nodes.Count != 0);
            if (ishookedOn)
            {
                ResetAll();
            }
            
            RayCastToMousePosition();
        }
        else if (playerController.UnHook)
        {
            ResetAll();
        }

        SetRopeRenderer();
    }

    void RayCastToMousePosition()
    {
        //1. Get mouse's wolrd point.
        var mouseWorldPoint =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        
        //2. Use RaycastHit to find the hit point.
        var direction = mouseWorldPoint - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, ropeMaxCastDistance, ropeLayerMask);

        if(hit.collider != null)
        {
            HookedHandler(hit.point);
        }
    }

    void HookedHandler(Vector2 hitPoint)
    {
        playerOnRopeMovement.IsHooked = true;

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
        //Create an empty game object and set its position to the hit point. Then add it to the node list.
        GameObject emptyGo = new GameObject("rope node");
        Transform tf = emptyGo.transform;
        tf.position = hitPoint;
        nodes.Add(tf);
    }

    void ActivateDistanceJoint(Vector2 hitPoint)
    {
        hingeManager.SetHingePosition(hitPoint);
    }

    void DeactivateDistanceJoint()
    {
        hingeManager.SetHingeDisable();
    }

    void SetRopeRenderer()
    {
        if (nodes.Count == 0)
            return;
        
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
        playerOnRopeMovement.IsHooked = false;
        DeactivateDistanceJoint();
    }
}
