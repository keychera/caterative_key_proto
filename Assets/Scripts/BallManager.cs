using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : Singleton<BallManager>
{
    List<Ball> balls;
    public delegate void BallCollideEvent(Ball whichBall, Brick whichBrick);
    public static event BallCollideEvent OnBallCollide;

    void Awake()
    {
        balls = new List<Ball>(GetComponentsInChildren<Ball>());
        foreach (var ball in balls)
        {
            ball.Deactivate();
        }
    }

    public Ball GetAvailableBall()
    {
        Ball availableBall = null;
        int i = 0;
        while (availableBall == null && i < balls.Count)
        {
            if (balls[i].active == false)
            {
                availableBall = balls[i];
            }
            i++;
        }
        return availableBall;
    }

    internal void InvokeOnBallCollide(Ball ball, Brick collidedBrick)
    {
        if (OnBallCollide != null) {
            OnBallCollide(ball,collidedBrick);
        }
        collidedBrick.Damage();
    }
}
