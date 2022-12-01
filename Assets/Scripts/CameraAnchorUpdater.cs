using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchorUpdater : MonoBehaviour
{
    [Tooltip("Follow Target")]
    public GameObject followTarget;

    void Start()
    {
        UpdatePosition();
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (followTarget)
        {
            transform.position = followTarget.transform.position;
        }
    }
}
