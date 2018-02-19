﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour {
	public Paddle paddle;

	void OnTriggerEnter2D(Collider2D col) {
		Ball ball = col.GetComponent<Ball>();
		if (ball != null) {
			GameManager.Instance.DamagePlayer(10);
			ball.transform.position = new Vector2(
				GameCamera.Instance.transform.position.x,
				GameCamera.Instance.transform.position.y
			);
			ball.Stop();
			paddle.ballToLaunch = ball;
		}
	}
}
