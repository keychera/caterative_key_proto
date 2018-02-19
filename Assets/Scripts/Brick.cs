using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool active;

    void Start()
    {
		active = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.rigidbody.GetComponent<Ball>();
        if (ball != null)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        transform.position = Vector2.up * 10000;
		active = false;
        BrickEventManager.Instance.InvokeOnBrickDestroy(this);
    }
}
