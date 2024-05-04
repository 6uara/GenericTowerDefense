using System;
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

    //public event Action enemyDied;
    private Transform target;
    private int pathIndex = 0;
    private int randomNum;

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
        randomNum = UnityEngine.Random.Range(1,10);
        var pos = new Vector3(transform.position.x,transform.position.y,transform.position.z -4);
        if(randomNum < 3)
        {
          Instantiate(drop,pos,transform.rotation);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            collision.gameObject.GetComponent<MainCastle>().TakeDamage(5);
            //enemyDied?.Invoke();
            Destroy(gameObject);
        }
    }
}
