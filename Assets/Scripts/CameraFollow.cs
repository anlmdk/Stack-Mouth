using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] 
    private float smoothSpeed = 0.3f;

    [SerializeField]
    private Vector3 offset;

    public Transform player;

    private void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        // The specified offset is added above the character position.
        // Then the target position is followed.
        Vector3 targetPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
