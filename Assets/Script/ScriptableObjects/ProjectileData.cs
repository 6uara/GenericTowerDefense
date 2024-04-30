using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Data", menuName = "Projectile Data/Projectile")]

public class ProjectileData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    public float Speed => speed;
    public int Damage => damage;

}
