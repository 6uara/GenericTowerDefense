using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private ProjectileData data;

    [SerializeField] private Rigidbody2D rb;
    
    private Transform target;

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
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(data.Damage);
            Destroy(gameObject,0.25f);
        }
    }
}
