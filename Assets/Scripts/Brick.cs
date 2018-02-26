using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool active;
    Rigidbody2D body;
    SpriteRenderer sprite;
    public int health = 5;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        active = true;
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            active = false;
            transform.position = Vector2.right * 1000;
            BrickManager.Instance.InvokeOnBrickDestroy(this);
        }
    }

    public void Put(Vector3 position)
    {
        active = true;
        transform.position = position;
    }
}
