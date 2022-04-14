using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    private Vector3 targetPosition;
    private Vector3 startingPosition;
    public float moveSpeed;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (followTarget != null)
        {
            targetPosition = new Vector3(
                followTarget.position.x,
                followTarget.position.y,
                transform.position.z);
            Vector3 velocity = (targetPosition - transform.position) * moveSpeed;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity, 1.0f, Time.deltaTime);
        }
    }
}
