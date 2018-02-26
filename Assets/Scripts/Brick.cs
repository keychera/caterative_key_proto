using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caterative.Brick.Destroyable;
using Caterative.Brick.Balls;

public class Brick : Destroyable, ICollidable
{
    public int health = 30;

    void ICollidable.OnCollideWithBall(Ball ball)
    {
        health -= ball.damage;
        if (health <= 0)
        {
            Destroy();
        }
    }
}
