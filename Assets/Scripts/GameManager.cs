using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Health playerHealth;
    Paddle paddle;
    public int counter;
    public delegate void CounterEvent(int counter);
    public static event CounterEvent OnChangeCounter;

    void Start()
    {
        counter = 0;
        playerHealth = FindObjectOfType<Health>();
        paddle = FindObjectOfType<Paddle>();
        StartCoroutine(LaunchinBallRoutine());

    }

    private IEnumerator LaunchinBallRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.64f);
            if (counter < 4)
            {
                counter++;
            }
            else
            {
                counter = 0;
                if (paddle.ballToLaunch == null)
                {
                    paddle.ballToLaunch = BallManager.Instance.GetAvailableBall();
                }
            }
            if (OnChangeCounter != null)
            {
                OnChangeCounter(counter);
            }
        }
    }

    public void ModifyPlayerHelth(int damage)
    {
        playerHealth.ModifyHealth(damage);
    }
}