using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnStateChanged;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.Level1:
                break;
            case GameState.Level2:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
        }

     OnStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    Menu,
    Level1,
    Level2,
    Victory,
    Lose
}
