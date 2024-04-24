using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] enemyPrefabs; // Array for two enemy prefabs
    public float spawnInterval = 2f;
    public int maxEnemies = 10;
    public Transform[] spawnPoints;

    private Queue<GameObject> enemyQueue;
    private int enemiesSpawned = 0;
    private float spawnTimer = 0f;

    private void Start()
    {
        // Initialize the enemy queue
        enemyQueue = new Queue<GameObject>();
        // Enqueue enemies in the desired order (repeat pattern if needed)
        enemyQueue.Enqueue(enemyPrefabs[0]);
        enemyQueue.Enqueue(enemyPrefabs[1]);
        // ... add more enemies to the queue as needed ...
    }

    private void Update()
    {
        if (enemiesSpawned >= maxEnemies || enemyQueue.Count == 0)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemyToSpawn = enemyQueue.Dequeue();
        Instantiate(enemyToSpawn, randomSpawnPoint.position, Quaternion.identity);
        enemiesSpawned++;

        // Re-enqueue the enemy to maintain the spawn order
        enemyQueue.Enqueue(enemyToSpawn);
    }
}
