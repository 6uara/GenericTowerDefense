using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 2f; // Time interval between enemy spawns
    public int maxEnemies = 10; // Maximum number of enemies to spawn
    public Transform[] spawnPoints; // Array of spawn points where enemies can spawn

    private int enemiesSpawned = 0;
    private float spawnTimer = 0f;

    private void Update()
    {
        // Check if the maximum number of enemies has been reached
        if (enemiesSpawned >= maxEnemies)
            return;

        // Count time for spawning
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random spawn point
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the enemy at the chosen spawn point
        Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Increment the counter for enemies spawned
        enemiesSpawned++;
    }
}
