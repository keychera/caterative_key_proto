using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public GameObject[] cooldownCounter;

    void Start()
    {
        DeactivateAll();
    }

	void OnEnable() {
		GameManager.OnChangeCounter += UpdateCooldown;
	}

	void OnDisable() {
		GameManager.OnChangeCounter -= UpdateCooldown;
	}

    private void DeactivateAll()
    {
        for (int i = 0; i < 4; i++)
        {
            cooldownCounter[i].SetActive(false);
        }
    }

    void UpdateCooldown(int counter)
    {
        if (counter == 0)
        {
            DeactivateAll();
        } else {
			cooldownCounter[counter-1].SetActive(true);		}
    }
}
