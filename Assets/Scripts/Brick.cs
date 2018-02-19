using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool active;
    Rigidbody2D body;
    public bool red = false;
    SpriteRenderer sprite;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
        red = false;
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

    internal void Redify()
    {
        red = true;
        StartCoroutine(RedifyRoutine());
    }

    private IEnumerator RedifyRoutine() {
        while(sprite.color.b > 0.2f) {
            sprite.color = new Color(
                sprite.color.r - 0.05f,
                0.8f,
                sprite.color.b - 0.05f
            );
            yield return new WaitForSeconds(0.1f);
        }
    }
}
