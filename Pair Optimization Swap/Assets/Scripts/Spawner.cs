using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float trajectoryVariance = 15.0f;

    public Asteroid asteroidPrefab;

    public float Rate = 2.0f;
    public int Amount = 1;

    public float Spawndistance = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 2.0f, this.Rate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.Amount; i++)
        {
            Vector3 SpawnDirection = Random.insideUnitCircle.normalized * this.Spawndistance;
            Vector3 spawn = this.transform.position + SpawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawn, rotation);
            asteroid.Size = Random.Range(asteroid.minsize, asteroid.maxsize);
            asteroid.Trajectory(rotation * -SpawnDirection);
        }
    }
}
