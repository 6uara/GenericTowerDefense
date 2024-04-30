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
        enemyQueue = new Queue<GameObject>();
        enemyQueue.InicializarCola(maxEnemies);
        enemyQueue.Acolar(enemyPrefabs[0]);
    }

    private void Update()
    {
        if (enemiesSpawned >= maxEnemies)
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
        GameObject enemyToSpawn = enemyQueue.Desacolar();
        Instantiate(enemyToSpawn, randomSpawnPoint.position, Quaternion.identity);
        enemiesSpawned++;

        enemyQueue.Acolar(enemyToSpawn);
    }
}
