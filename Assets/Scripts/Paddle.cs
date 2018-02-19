using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using caterative.math;

public class Paddle : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 5f;
    public float launchDirection;
	public Ball ballToLaunch;
    public LineRenderer targetLine;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            body.velocity = (Vector2.right * speed);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            body.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            body.velocity = (Vector2.left * speed);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            body.velocity = Vector2.zero;
        }
        if (ballToLaunch != null)
        {
			targetLine.positionCount = 2;
            launchDirection = 90 + ((transform.position.x / 2) * -45);
			Vector2 originalBallLocation = new Vector2(
				transform.position.x * 1.25f,
				transform.position.y + 0.2f
			);
			ballToLaunch.transform.position = originalBallLocation;
            targetLine.SetPosition(0, originalBallLocation);
            Vector2 launchVector = Transformation.RotateVector(Vector2.right, launchDirection);
            int layerMask = LayerMask.GetMask("Default");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, launchVector, 100, layerMask);
            if (hit.collider != null)
            {
                targetLine.SetPosition(1, hit.point);
            } else {
				targetLine.SetPosition(1, launchVector*10);
			}
        }
		if (Input.GetKeyUp(KeyCode.Space)) {
			ballToLaunch.LaunchTowardsAngle(launchDirection);
			ballToLaunch = null;
			targetLine.positionCount = 0;
		}
    }
}
