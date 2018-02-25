using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : Singleton<BallManager>
{
    List<Ball> balls;

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
            Debug.Log(balls[i].active);
            if (balls[i].active == false)
            {
                availableBall = balls[i];
            }
            i++;
        }
        return availableBall;
    }
}
