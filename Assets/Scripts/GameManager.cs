using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Health playerHealth;
    Paddle paddle;

    void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        paddle = FindObjectOfType<Paddle>();
        StartCoroutine(LaunchinBallRoutine());

    }

    private IEnumerator LaunchinBallRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("checking Ball!");
            if (paddle.ballToLaunch == null)
            {
                paddle.ballToLaunch = BallManager.Instance.GetAvailableBall();
            }
        }
    }

    public void DamagePlayer(int damage)
    {
        playerHealth.ModifyHealth(-1 * damage);
    }
}