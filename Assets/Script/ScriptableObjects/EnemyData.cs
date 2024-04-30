using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data/Enemy")]

public class EnemyData : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed => speed;
}
