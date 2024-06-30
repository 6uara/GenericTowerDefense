using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum TurretColor
{
    red = 0,
    blue = 1
}

public class TurretScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField]private GameObject projectilePrefab;
    [SerializeField]private Transform firePoint;

    private Queue<UnityEngine.GameObject> enemyQueue;

    private float timer = 2;
    private float timeUntilFire = 0;
    private int enemyQuantity = 20;
    private GameObject actualEnemy;

    private void Start()
    {
        enemyQueue = new Queue<GameObject>();
        enemyQueue.InicializarCola(enemyQuantity);

        timeUntilFire = 0f;
        timer = 2;
    }

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (!enemyQueue.ColaVacia())
        {
            if (timeUntilFire >= 1f / timer)
            {
                actualEnemy = enemyQueue.Primero();
                if (actualEnemy != null)
                {
                    Shoot(actualEnemy.transform);
                }
                timeUntilFire = 0;
            }
        }
    }

    private void Shoot(Transform enemyTransform)
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        ProjectileScript bulletScript = bullet.GetComponent<ProjectileScript>();
        bulletScript.SetTarget(enemyTransform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyQueue.Acolar(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyQueue.Desacolar();
        }
    }
}
