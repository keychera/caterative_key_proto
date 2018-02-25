using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Health playerHealth;
    Paddle paddle;

    void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        paddle = FindObjectOfType<Paddle>();
    }

    void Start() {
        ReadyTheBall();
    }

    void OnEnable() {
        DamageZone.OnBallLoss += RestartBall;
    }

    void OnDisable() {
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

    public void RestartBall(Ball ball) {
        GameManager.Instance.ModifyPlayerHelth(-1 * ball.damage);
        ball.Deactivate();
        GameManager.Instance.ReadyTheBall();
    }
}