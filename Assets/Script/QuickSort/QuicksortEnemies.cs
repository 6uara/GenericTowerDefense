using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicksortEnemies : MonoBehaviour
{
        private List<BaseEnemy> enemiesIds = new List<BaseEnemy>();

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
