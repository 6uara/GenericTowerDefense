using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxEnemies = 20;

    private Queue<GameObject> enemyQueue;
    private int enemiesSpawned = 0;
    private float spawnTimer = 0f;
    private float nextSpawnTime = 0;

    private void Start()
    {
        enemyQueue = new Queue<GameObject>(maxEnemies);
        enemyQueue.Enqueue(enemyPrefabs[0]);
        enemyQueue.Enqueue(enemyPrefabs[1]);
    }

    private void Update()
    {
        if (enemiesSpawned >= maxEnemies || enemyQueue.Count() == 0)
        {
            return;
        }

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnEnemy();

            float randomInterval = Random.Range(1f, 4f);
            nextSpawnTime = Time.time + randomInterval;
        }
        spawnTimer += Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemyToSpawn = enemyQueue.Dequeue();
        Instantiate(enemyToSpawn, randomSpawnPoint.position, Quaternion.identity);
        enemiesSpawned++;

        enemyQueue.Enqueue(enemyToSpawn);
    }
}
