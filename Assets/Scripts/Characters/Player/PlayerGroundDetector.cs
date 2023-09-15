using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = .1f;
    [SerializeField] LayerMask groundLayer;

    Collider[] colliders = new Collider[1];

    public bool IsGrounded
    {
        get
        {
            return ((Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, detectionRadius);
    }
}
