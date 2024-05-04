using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxEnemies = 20;

    private Stack enemyStack;

    public event Action lastEnemy;
    private int enemiesSpawned = 0;
    private float spawnTimer = 0f;
    private float winTimer;

    private void Start()
    {
        enemyStack = new Stack();
        for (int i = 0; i < maxEnemies; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                enemyStack.Apilar(enemyPrefabs[0]);
            }
        }
        
    }

    private void Update()
    {
        if (enemiesSpawned >= maxEnemies)
        {

           winTimer += Time.deltaTime;
            if (winTimer > 10f)
            {
                lastEnemy?.Invoke();
            }
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
        if (! enemyStack.PilaVacia())
        {
            Transform randomSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            GameObject enemyToSpawn = enemyStack.Tope();
            enemyStack.Desapilar();
            Instantiate(enemyToSpawn, randomSpawnPoint.position, Quaternion.identity);
            enemiesSpawned++;
        }
    }
}