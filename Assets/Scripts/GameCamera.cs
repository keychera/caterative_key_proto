using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : Singleton<GameCamera>
{
    public List<GameObject> objectsRelativeToCamera;
    public Vector2[] relativeDistancesOfObjects;
    Vector3 targetPosition;
    public float maxDistancePerFrame = 2;

    void OnEnable()
    {
        BrickEventManager.OnBrickDestroy += UpdateRelativePositionsToBrick;
    }

    void Update()
    {
        float partialDistanceToTarget = Vector2.Distance(transform.position, targetPosition) * 0.1f;
        float distancePerFrame = 
            (partialDistanceToTarget > maxDistancePerFrame)?
            maxDistancePerFrame : partialDistanceToTarget
        ;
        transform.position = Vector3.Lerp(
            transform.position, targetPosition, 
            distancePerFrame * Time.deltaTime
        );
        for (int i = 0; i < objectsRelativeToCamera.Count; i++)
        {
            Transform relativeObject = objectsRelativeToCamera[i].transform;
            relativeObject.position = new Vector2(
                relativeObject.position.x,
                transform.position.y + relativeDistancesOfObjects[i].y
            );
        }
    }

    private void UpdateRelativePositionsToBrick(Brick whichBrick)
    {
        if (whichBrick != null)
        {
            targetPosition = new Vector3(0, whichBrick.transform.position.y, -10);
        }
        else
        {
            targetPosition = Vector2.right;
        }
    }

    void OnDisable()
    {
        BrickEventManager.OnBrickDestroy -= UpdateRelativePositionsToBrick;
    }
}
