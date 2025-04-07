using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 2f;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Astroid"))
        {
            Destroy(collision.gameObject); 
            GameManager.Instance.AddScore(10); 
            Destroy(gameObject); 
        }
    }
}
