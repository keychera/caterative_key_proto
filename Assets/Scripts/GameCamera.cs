using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        BrickManager.OnBrickDestroy += UpdateRelativePositionsToBrick;
    }

    void OnDisable()
    {
        BrickManager.OnBrickDestroy -= UpdateRelativePositionsToBrick;
    }

    void Start()
    {
        UpdateRelativePositionsToBrick(BrickManager.Instance.GetClosestBrick());
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
                (Vector2)transform.position, targetPosition, distancePerFrame * Time.deltaTime
            );
            newPosition = new Vector3(newPosition.x, newPosition.y, -10);
            Debug.Log(newPosition);
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

    private void UpdateRelativePositionsToBrick(Brick whichBrick)
    {
        if (whichBrick != null)
        {
            noTarget = false;
            targetPosition = new Vector3(0, whichBrick.transform.position.y, -10);
        }
        else
        {
            noTarget = true;
            targetPosition = Vector2.zero;
        }
    }
}
