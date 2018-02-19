using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D collision) {
		Ball ball = collision.rigidbody.GetComponent<Ball>();
		if (ball != null) {
			Destroy();
		}
	}

	public void Destroy() {
		transform.position = Vector2.right * 100;
	}
}
