using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionExit(Collision collision)
    {
        var velocity = rb.linearVelocity;

        velocity += velocity.normalized * 0.01f;

        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        if (velocity.magnitude > 3.0f) velocity = velocity.normalized * 3.0f;
        rb.linearVelocity = velocity;
    }
}
