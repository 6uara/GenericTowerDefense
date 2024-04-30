using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField]private GameObject projectilePrefab;
    [SerializeField]private Transform firePoint;

    private Stack<GameObject> enemyStack;

    private Queue<GameObject> enemyQueue;

    private float timer = 2;
    private float timeUntilFire = 0;
    private int enemyQuantity = 20;
    private GameObject actualEnemy;

    private void Start()
    {
        enemyStack = new Stack<GameObject>();

        enemyQueue = new Queue<GameObject>();

        enemyStack.InicializarPila(enemyQuantity);

        enemyQueue.InicializarCola(enemyQuantity);

        timeUntilFire = 0f;
        timer = 2;
    }

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        //if (!enemyStack.PilaVacia())
        //{
        //    if (timeUntilFire >= 1f/timer)
        //    {
        //        actualEnemy = enemyStack.Tope();
        //        if (actualEnemy != null)
        //        {
        //            Shoot(actualEnemy.transform);
        //        }
        //        timeUntilFire = 0;
        //    }
        //}

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
            //enemyStack.Apilar(other.gameObject);
            Debug.Log("Enemigo entró en el rango de la torreta");
            enemyQueue.Acolar(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //enemyStack.Desapilar();
            enemyQueue.Desacolar();
        }
    }
}
