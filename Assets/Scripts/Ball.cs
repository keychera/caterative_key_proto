using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using caterative.math;

public class Ball : MonoBehaviour
{
    Rigidbody2D body;
    public bool launchAfterStart;
    public float initialDirection = 45f;
    public float speedFactor = 5;
    private Vector2 constantVelocity;
    private float constantVelocityMagnitude;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (launchAfterStart)
        {
            LaunchTowardsAngle(initialDirection);
        }
    }

    public void LaunchTowardsAngle(float direction)
    {
        body.velocity = Vector2.zero;
        Vector2 directionVector = Transformation.RotateVector(Vector2.right,direction);
        constantVelocity = (directionVector * speedFactor);
        constantVelocityMagnitude = constantVelocity.magnitude;
        body.velocity = constantVelocity;
    }

    public void Stop() {
        body.velocity = Vector2.zero;
    }

    void Update() {
        constantVelocity = body.velocity;
        if (constantVelocity.magnitude != constantVelocityMagnitude) {
            constantVelocity = constantVelocity.normalized * speedFactor;
        }
    }

    void LateUpdate() {
        body.velocity = constantVelocity;
    }
}
