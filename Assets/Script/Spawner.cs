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

    private void Start()
    {
        enemyQueue = new Queue<GameObject>();
        // No es necesario inicializar la cola con un enemigo en el inicio
        enemyQueue.InicializarCola(maxEnemies);
    }

    private void Update()
    {
        if (enemiesSpawned >= maxEnemies)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f; // Reiniciar el temporizador de spawn
        }
    }

    private void SpawnEnemy()
    {
        if (enemiesSpawned < maxEnemies)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemyToSpawn, randomSpawnPoint.position, Quaternion.identity);
            enemiesSpawned++;
        }
    }
}