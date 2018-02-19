using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEventManager : Singleton<BrickEventManager>
{
    public delegate void BrickEvent(Brick whichBrick);
    public static event BrickEvent OnBrickDestroy;

    public void InvokeOnBrickDestroy(Brick brick)
    {
        Debug.Log("entering the Invocation");
        if (OnBrickDestroy != null)
        {
            OnBrickDestroy(GetClosestBrick());
        }
    }

    public Brick GetClosestBrick()
    {
        Brick[] allBricks = FindObjectsOfType<Brick>();
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
		Debug.Log(closestBrick.gameObject.name);
        return closestBrick;
    }

}
