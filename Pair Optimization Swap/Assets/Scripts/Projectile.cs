using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 2f;
    public ParticleSystem ps;

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
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);

            ps.transform.parent = null;
            ps.Play();

            Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);

            Destroy(gameObject);
        }
    }
}
