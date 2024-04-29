using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField]private GameObject projectilePrefab;
    [SerializeField]private Transform firePoint;
    [SerializeField]private float fireRate = 2f;

    private Stack<GameObject> enemyStack;

    private float timer = 2;
    private float timeUntilFire = 0;
    private int enemyQuantity = 20;
    private GameObject actualEnemy;

    private void Start()
    {
        enemyStack = new Stack<GameObject>();
        enemyStack.InicializarPila(enemyQuantity);
        timeUntilFire = 0f;
        timer = 2;
    }

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        if (!enemyStack.PilaVacia())
        {
            if (timeUntilFire >= 1f/timer)
            {
                actualEnemy = enemyStack.Tope();
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
            enemyStack.Apilar(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyStack.Desapilar();
        }
    }
}
