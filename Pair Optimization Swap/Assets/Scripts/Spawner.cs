using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float trajectoryVariance = 15.0f;

    [SerializeField] private Asteroid asteroidPrefab;

    private float Rate = 2.0f;
    private int Amount = 1;

    private float Spawndistance = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 2.0f, Rate);
    }

    private void Spawn()
    {
        for (int i = 0; i < Amount; i++)
        {
            Vector3 SpawnDirection = Random.insideUnitCircle.normalized * Spawndistance;
            Vector3 spawn = transform.position + SpawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(asteroidPrefab, spawn, rotation);
            asteroid.Size = Random.Range(asteroid.minsize, asteroid.maxsize);
            asteroid.Trajectory(rotation * -SpawnDirection);
        }
    }
}
