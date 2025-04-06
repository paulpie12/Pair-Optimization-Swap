using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float Size = 1.0f;
    public float minsize = 0.5f;
    public float maxsize = 1.0f;
    public float speed = 50.0f;
    public float lifespan = 30.0f;

    private SpriteRenderer SR;
    private Rigidbody2D RB;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        SR.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 250.0f);
        this.transform.localScale = Vector3.one * this.Size;

        RB.mass = this.Size;
    }

    public void Trajectory(Vector2 direction)
    {
        RB.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.lifespan);
    }

}
