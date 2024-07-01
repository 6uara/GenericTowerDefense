using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [SerializeField] private GameObject[] towerPrefabs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject GetSelectedTower(int selectedTower)
    {
        return towerPrefabs[selectedTower];
    }
}
