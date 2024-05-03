using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCastle : MonoBehaviour
{
    [SerializeField] private float health = 50;

    [SerializeField] private float damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5);
            collision.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Event
        }
    }
}
