using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	Health playerHealth;

	void Start() {
		playerHealth = FindObjectOfType<Health>();
	}

	public void DamagePlayer(int damage) {
		playerHealth.ModifyHealth(-1*damage);
	}
}