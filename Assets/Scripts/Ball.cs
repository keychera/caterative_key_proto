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
    public float speedFactor = 5f;
    private Vector2 constantVelocity;
    private float constantVelocityMagnitude;
    public int damage;
    private float slowFactor = 0.1f;
    public bool active = false;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        if (launchAfterStart)
        {
            LaunchTowardsAngle(initialDirection);
        }
    }

    public void LaunchTowardsAngle(float direction)
    {
        active = true;
        body.velocity = Vector2.zero;
        Vector2 directionVector = Transformation.RotateVector(Vector2.right,direction);
        constantVelocity = (directionVector * speedFactor);
        constantVelocityMagnitude = constantVelocity.magnitude;
        body.velocity = constantVelocity;
    }

    public void Deactivate() {
        active = false;
        body.velocity = Vector2.zero;
        transform.position = Vector2.right * 1000;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (body.velocity.magnitude < 1f) {
            Deactivate();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.GetComponent<Paddle>()) {
            constantVelocity = body.velocity;
            body.velocity = constantVelocity.normalized * (speedFactor);
        }
    }
/* 
for constant velocity
    void Update() {
        constantVelocity = body.velocity;
        if (constantVelocity.magnitude != constantVelocityMagnitude) {
            constantVelocity = constantVelocity.normalized * (speedFactor);
        }
    }

    void LateUpdate() {
        body.velocity = constantVelocity;
    }*/
}
