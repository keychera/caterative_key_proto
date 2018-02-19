using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            LaunchTowardsAngle(initialDirection,speedFactor);
        }
    }

    public void LaunchTowardsAngle(float direction, float initialFactor)
    {
        body.velocity = Vector2.zero;
        Vector2 directionVector = RotateVector(Vector2.right,direction);
        constantVelocity = (directionVector * initialFactor);
        constantVelocityMagnitude = constantVelocity.magnitude;
        body.velocity = constantVelocity;
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

    private Vector2 RotateVector(Vector2 vector, float angle) {
        Vector2 rotatedVector = vector;
        float _x = rotatedVector.x;
        float _y = rotatedVector.y;
        float angleInRadian = (angle/360) * (2 * Mathf.PI);
        float _cos = Mathf.Cos(angleInRadian);
        float _sin = Mathf.Sin(angleInRadian);
        rotatedVector.x = _x * _cos - _y * _sin;
        rotatedVector.y = _x * _sin + _y * _cos;
        return rotatedVector;
    }
}
