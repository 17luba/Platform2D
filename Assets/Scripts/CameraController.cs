using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    public Vector3 positionOffset;

    [Range(0, 1)]
    public float smoothTime;

    [Header("Axis Limitations")]
    public Vector2 xLimits;
    public Vector2 yLimits;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        targetPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, xLimits.x, xLimits.y),
            Mathf.Clamp(targetPosition.y, yLimits.x, yLimits.y),
            targetPosition.z
        );
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
