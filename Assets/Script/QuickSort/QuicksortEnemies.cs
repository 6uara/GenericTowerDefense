using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies
{
    public int Id { get; set; }

    public Enemies(int id)
    {
        Id = id;
    }
}

public class QuicksortEnemies : MonoBehaviour
{
        private List<Enemies> enemiesIds = new List<Enemies>();

        void Start()
        {

        }

        private void Update()
        {

        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Letter"))
            {

            }
        }

        private void UpdateStack()
        {

        }
    }
