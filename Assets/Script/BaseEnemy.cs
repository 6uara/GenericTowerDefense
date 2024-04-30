using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;

    [Header("Attributes")]
    [SerializeField] private GameObject drop;
    [SerializeField] private int health;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        if (LevelManager.main.path.Length > 0)
        {
            target = LevelManager.main.path[pathIndex];
        }
        else
        {
            Debug.LogError("Path not defined in LevelManager!");
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex >= LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * data.Speed;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject);
        Instantiate(drop,transform.position,transform.rotation);
    }
}
