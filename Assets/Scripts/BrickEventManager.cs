using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEventManager : Singleton<BrickEventManager>
{
    public delegate void BrickEvent(Brick whichBrick);
    public static event BrickEvent OnBrickDestroy;

    public void InvokeOnBrickDestroy(Brick brick)
    {
        if (OnBrickDestroy != null)
        {
            OnBrickDestroy(GetClosestBrick());
        }
    }

    public Brick GetClosestBrick()
    {
        Brick[] allBricks = GetActiveBrick();
        Brick closestBrick = null;
        if (allBricks.Length > 0)
        {
            closestBrick = allBricks[0];
            for (int i = 1; i < allBricks.Length; i++)
            {
                if (allBricks[i].transform.position.y < closestBrick.transform.position.y)
                {
                    closestBrick = allBricks[i];
                }
            }
        }
        return closestBrick;
    }

    private Brick[] GetActiveBrick()
    {
        var allBricks = new List<Brick>(FindObjectsOfType<Brick>());
        for(int i = allBricks.Count - 1; i >= 0; i--)
        {
            if (!allBricks[i].active) {
                allBricks.RemoveAt(i);
            }
        }
        return allBricks.ToArray();
    }
}
