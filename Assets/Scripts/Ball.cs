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
    TrailRenderer trail;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        if (launchAfterStart)
        {
            LaunchTowardsAngle(initialDirection);
        }
    }

    public void LaunchTowardsAngle(float direction)
    {
        active = true;
        trail.Clear();
        trail.enabled = true;
        body.velocity = Vector2.zero;
        Vector2 directionVector = Transformation.RotateVector(Vector2.right,direction);
        constantVelocity = (directionVector * speedFactor);
        constantVelocityMagnitude = constantVelocity.magnitude;
        body.velocity = constantVelocity;
        trail.time = body.velocity.magnitude * 0.25f;
    }

    public void Deactivate() {
        active = false;
        trail.enabled = false;
        body.velocity = Vector2.zero;
        transform.position = Vector2.right * 1000;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        trail.time = body.velocity.magnitude * 0.25f;
        if (body.velocity.magnitude < 1f) {
            Deactivate();
        }
        Brick brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null && brick.red) {
            GameManager.Instance.ModifyPlayerHelth(15);
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
