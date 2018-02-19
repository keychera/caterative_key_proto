using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	Rigidbody2D body;
	public float speed = 3f;
	void  Start() {
		body = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.D)) {
			body.velocity = (Vector2.right * speed);
		} else if (Input.GetKeyUp(KeyCode.D)) {
			body.velocity = Vector2.zero;
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			body.velocity = (Vector2.left * speed);
		} else if (Input.GetKeyUp(KeyCode.A)) {
			body.velocity = Vector2.zero;
		}
	}
}
