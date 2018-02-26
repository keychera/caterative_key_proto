using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caterative.Brick.Destroyable;

public class GameCamera : Singleton<GameCamera>
{
    public List<GameObject> objectsRelativeToCamera;
    public Vector2[] relativeDistancesOfObjects;
    Vector3 targetPosition;
    bool noTarget;
    public float moveFactor = 0.1f;
    public float maxDistancePerFrame = 8;

    void OnEnable()
    {
        DestroyableManager.OnDestroyableDestroy += UpdateRelativePositionsToBrick;
    }

    void OnDisable()
    {
        DestroyableManager.OnDestroyableDestroy -= UpdateRelativePositionsToBrick;
    }

    void Start()
    {
        UpdateRelativePositionsToBrick(DestroyableManager.Instance.GetClosestDestroyable());
    }

    void Update()
    {
        if (!noTarget)
        {
            float partialDistanceToTarget = Vector2.Distance(transform.position, targetPosition) * moveFactor;
            float distancePerFrame =
                (partialDistanceToTarget > maxDistancePerFrame) ?
                maxDistancePerFrame : partialDistanceToTarget
            ;
            Vector3 newPosition = Vector3.MoveTowards(
                transform.position, targetPosition, distancePerFrame * Time.deltaTime
            );
            transform.position = newPosition;
            for (int i = 0; i < objectsRelativeToCamera.Count; i++)
            {
                Transform relativeObject = objectsRelativeToCamera[i].transform;
                relativeObject.position = new Vector2(
                    relativeObject.position.x,
                    transform.position.y + relativeDistancesOfObjects[i].y
                );
            }
        }
    }

    private void UpdateRelativePositionsToBrick(Destroyable whichDestroyable)
    {
        if (whichDestroyable != null)
        {
            noTarget = false;
            if (whichDestroyable.transform.position.y - transform.position.y > 2)
            targetPosition = new Vector3(0, whichDestroyable.transform.position.y - 2, -10);
        }
        else
        {
            noTarget = true;
            targetPosition = Vector2.zero;
        }
    }
}
