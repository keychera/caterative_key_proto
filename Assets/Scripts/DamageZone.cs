using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Ball ball = col.GetComponent<Ball>();
		if (ball != null) {
			GameManager.Instance.DamagePlayer(10);
			ball.transform.position = Vector2.zero;
			ball.LaunchTowardsAngle(Random.Range(45,135),5);
		}
	}
}
