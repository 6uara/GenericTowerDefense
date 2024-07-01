using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private ProjectileData data;

    [SerializeField] private Rigidbody2D rb;
    
    private Transform target;
    [SerializeField] private int Id;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * data.Speed;
        }
    }
    public void SetTarget(Transform enemyTarget)
    {
        target = enemyTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.GetComponent<BaseEnemy>().Id == Id)
            {
                collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(data.Damage * 2);
            }
            else
            {
                collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(data.Damage);
            }
            Destroy(gameObject);
        }
    }
}
