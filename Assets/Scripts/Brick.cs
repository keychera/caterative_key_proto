using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool active;
    Rigidbody2D body;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
		active = true;
        body.velocity = Vector2.down * 0.2f;
        transform.localRotation = Quaternion.Euler(0,0,Random.Range(45,135));
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
        transform.position = new Vector2(
            Random.Range(-1.5f,1.5f),
            Random.Range(
                36f * GameCamera.Instance.transform.position.y,
                45f + GameCamera.Instance.transform.position.y * 1.5f
            )
        );
        transform.localRotation = Quaternion.Euler(0,0,Random.Range(45,135));
        body.velocity = Vector2.down * 0.2f;
        BrickManager.Instance.InvokeOnBrickDestroy(this);
    }
}
