using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Ball ball = col.GetComponent<Ball>();
		if (ball != null) {
			GameManager.Instance.ModifyPlayerHelth(-1* ball.damage);
			ball.Deactivate();
		}
	}
}
