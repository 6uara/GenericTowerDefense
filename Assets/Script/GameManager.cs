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
    private TheSceneManager sceneManager;

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

    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TheSceneManager>();
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
        Debug.Log(SceneManager.GetActiveScene().ToString());
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            sceneManager.FinishedTutorial();
            Debug.Log("Tutorial terminado..., desbloqueando niveles");
        }
        sceneManager.LoadNewScene("VictoryScene");
    }

    private void Lose()
    {
        sceneManager.LoadNewScene("LoseScene");
    }
}

