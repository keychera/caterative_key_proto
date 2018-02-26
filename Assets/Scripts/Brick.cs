using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool active;
    Rigidbody2D body;
    SpriteRenderer sprite;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
		active = true;
    }

    public void Destroy()
    {
        active = false;
        transform.position = Vector2.right * 1000;
        BrickManager.Instance.InvokeOnBrickDestroy(this);
    }

    public void Put(Vector3 position) {
        active = true;
        transform.position = position;
    }
}
