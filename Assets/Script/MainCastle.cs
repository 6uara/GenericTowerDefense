using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;

public class MainCastle : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 50;
    public event Action Defeat;

    public int GetHealth()
    {
        return (int)health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Defeat?.Invoke();
        }
    }
}
