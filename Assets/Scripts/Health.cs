using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public RectTransform whiteBar;
    public RectTransform redBar;
    public float test;

    void Update()
    {
        test = ((float)(maxHealth - health) / (float)maxHealth) * whiteBar.sizeDelta.y;
        redBar.localPosition = new Vector2(
            redBar.localPosition.x,
            0 - test
        );
    }

	public void ModifyHealth(int modifier) {
		health += modifier;
        if (health > maxHealth) health = maxHealth;
        if (health < 0) health = 0;
	}
}