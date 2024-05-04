using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MainCastle castle;
        [SerializeField] private Spawner enemySpawner;

        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            castle.Defeat += Lose; // Suscribirse al evento Defeat del castillo
            enemySpawner.lastEnemy += Victory;
        }

        private void OnDisable()
        {
            castle.Defeat -= Lose; // Asegurarse de desuscribirse cuando el GameManager se desactive
            enemySpawner.lastEnemy -= Victory;
    }

        private void Victory()
        {
            TheSceneManager.Instance.LoadNewScene("VictoryScene");
        }

        private void Lose()
        {
            TheSceneManager.Instance.LoadNewScene("LoseScene");
        }
    }

