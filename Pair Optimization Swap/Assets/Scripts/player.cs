using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private float forwardspeed = 1.0f;
    private float turnspeed = 1.0f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    private float fireCooldown = 0.5f;
    [SerializeField] private ParticleSystem ps;

    private Rigidbody2D rigidbody;
    private bool Forward;
    private float turnDirection;
    public bool lose = false;
    private float fireTimer;
    private Renderer Ren;

    private void Awake()
    {
        Ren = GetComponent<Renderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Forward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }

        fireTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireCooldown;
        }

        if (lose == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            Invoke("pause", 1f);
        }
    }

    private void pause()
    {
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        if (Forward)
        {
            rigidbody.AddForce(this.transform.up * this.forwardspeed);
        }
        if (turnDirection != 0.0f)
        {
            rigidbody.AddTorque(turnDirection * this.turnspeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Astroid"))
        {
            ps.Play();
            Ren.material.color = Color.clear;
            lose = true;

            GameManager.Instance.PlayerHit(); 
        }
    }


    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        }
    }
}
