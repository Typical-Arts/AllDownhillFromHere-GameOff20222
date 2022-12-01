using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingEffects : MonoBehaviour
{
    [Tooltip("Boulder Rigidbody")]
    public Rigidbody boulderRigidbody;

    [Tooltip("Speedline Trail Renderer")]
    public TrailRenderer speedlineTrailRenderer;

    [Tooltip("Max Speedline Velocity")]
    [Range(1f, 50f)]
    public float maxSpeedlineVelocity = 20f;

    void Update()
    {
        UpdateTrailOpacity();
    }

    void OnCollisionEnter()
    {
        // TODO: Begin emitting rolling effects when colliding with terrain
    }

    void OnCollisionExit()
    {
        // TODO: Stop emitting rolling effects
    }

    void UpdateTrailOpacity()
    {
        speedlineTrailRenderer.material.SetFloat(
            "_Opacity", 
            Mathf.InverseLerp(0f, maxSpeedlineVelocity, boulderRigidbody.velocity.magnitude)
        );
    }
}
