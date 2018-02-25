using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : Singleton<DamageZone>
{
    public delegate void BallLossEvent(Ball whichBall);
    public static event BallLossEvent OnBallLoss;

    void OnTriggerEnter2D(Collider2D col)
    {
        Ball ball = col.GetComponent<Ball>();
        if (ball != null)
        {
            if (OnBallLoss != null)
            {
                OnBallLoss(ball);
            }
        }
    }
}
