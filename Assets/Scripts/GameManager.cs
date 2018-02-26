using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caterative.Brick.Balls;

public class GameManager : Singleton<GameManager>
{
    Health playerHealth;
    Paddle paddle;
    public Text loseText;

    void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        paddle = FindObjectOfType<Paddle>();
    }

    void Start()
    {
        loseText.gameObject.SetActive(false);
        ReadyTheBall();
    }

    void OnEnable()
    {
        DamageZone.OnBallLoss += RestartBall;
    }

    void OnDisable()
    {
        DamageZone.OnBallLoss -= RestartBall;
    }

    public void ReadyTheBall()
    {
        paddle.ballToLaunch = BallManager.Instance.GetAvailableBall();
    }

    public void ModifyPlayerHelth(int damage)
    {
        playerHealth.ModifyHealth(damage);
    }

    public void RestartBall(Ball ball)
    {
        GameManager.Instance.ModifyPlayerHelth(-1 * ball.damage);
        if (playerHealth.health > 0)
        {
            ball.Deactivate();
            GameManager.Instance.ReadyTheBall();
        }
        else
        {
            paddle.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
        }
    }
}