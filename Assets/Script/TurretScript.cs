using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab; // Projectile prefab to shoot
    public Transform firePoint; // Point from where projectiles are fired
    public float fireRate = 1f; // Rate of fire (projectiles per second)
    public float rotationSpeed = 5f; // Speed at which the turret rotates

    private GameObject targetEnemy; // Reference to the current target enemy
    private float fireTimer; // Timer to control firing rate

    private void Update()
    {
        // Find the nearest enemy
        FindNearestEnemy();

        // If there's a target enemy, aim and shoot
        if (targetEnemy != null)
        {
            // Rotate turret to aim at the target enemy
            Vector2 direction = targetEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // Fire projectile if enough time has passed since the last shot
            fireTimer += Time.deltaTime;
            if (fireTimer >= 1f / fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    private void FindNearestEnemy()
    {
        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If there are no enemies, return
        if (enemies.Length == 0)
        {
            targetEnemy = null;
            return;
        }

        // Find the nearest enemy
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // Set the nearest enemy as the target
        targetEnemy = nearestEnemy;
    }

    private void Shoot()
    {
        // Instantiate a projectile at the fire point
        Instantiate(projectilePrefab, firePoint.position, transform.rotation);
    }
}
