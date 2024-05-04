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

    private Stack<GameObject> EnemyStack;

    public event Action lastEnemy;
    private int enemiesSpawned = 0;
    private float spawnTimer = 0f;
    private float winTimer;

    private void Start()
    {
        EnemyStack = new Stack<GameObject>();
        EnemyStack.InicializarPila(20);
        for (int i = 0; i < maxEnemies; i++)
        {
                EnemyStack.Apilar(enemyPrefabs[0]);
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
            spawnInterval -= 0.1f;
        }
    }

    private void SpawnEnemy()
    {
        if (! EnemyStack.PilaVacia())
        {
            Transform randomSpawnPoint = spawnPoints[0];
            GameObject enemyToSpawn = EnemyStack.Tope();
            EnemyStack.Desapilar();
            Instantiate(enemyToSpawn, randomSpawnPoint.position, Quaternion.identity);
            enemiesSpawned++;
        }
    }
}