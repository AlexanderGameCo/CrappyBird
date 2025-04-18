using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Obstacle PipeObject;
    public float SpawnInterval = 5f;
    public Transform SpawnPosition;
    private float timer;
    private float difficulty = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnInterval)
        {
            Spawn();
            timer = 0f;
        }
        difficulty = math.clamp(difficulty + 0.00001f, 0f, 1f);
    }

    void Spawn()
    {
        var obstacle = Instantiate(PipeObject, SpawnPosition.position, Quaternion.identity);
        obstacle.SetDifficulty(difficulty);
    }
}
