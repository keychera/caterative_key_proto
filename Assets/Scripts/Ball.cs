using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Caterative.Math;

namespace Caterative.Brick.Balls
{
    public class Ball : MonoBehaviour
    {
        Rigidbody2D body;
        public float speedFactor = 5f;
        public int damage;
        internal bool active = false;
        TrailRenderer trail;
        Vector2 constantVelocity;
        float constantVelocityMagnitude;

        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            trail = GetComponent<TrailRenderer>();
            trail.enabled = false;
        }

        public void LaunchTowardsAngle(float direction)
        {
            active = true;
            trail.Clear();
            trail.enabled = true;
            body.velocity = Vector2.zero;
            Vector2 directionVector = Transformation.RotateVector(Vector2.right, direction);
            constantVelocity = (directionVector * speedFactor);
            constantVelocityMagnitude = constantVelocity.magnitude;
            body.velocity = constantVelocity;
            trail.time = body.velocity.magnitude * 0.25f;
        }

        public void Deactivate()
        {
            active = false;
            trail.enabled = false;
            body.velocity = Vector2.zero;
            transform.position = Vector2.right * 1000;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            trail.time = body.velocity.magnitude * 0.25f;
            ICollidable collidedCollidable = collision.gameObject.GetComponent<ICollidable>();
            if (collidedCollidable != null)
            {
                BallManager.Instance.InvokeOnBallCollide(this, collidedCollidable);
                collidedCollidable.OnCollideWithBall(this);
            }
        }


        void Update()
        {
            constantVelocity = body.velocity;
            if (constantVelocity.magnitude != constantVelocityMagnitude)
            {
                constantVelocity = constantVelocity.normalized * (speedFactor);
            }
        }

        void LateUpdate()
        {
            body.velocity = constantVelocity;
        }
    }
}