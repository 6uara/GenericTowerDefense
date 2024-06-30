using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsChecker : MonoBehaviour
{
    private Tree levelTree;
    private int levelIndex = SceneManager.sceneCount;

    private void Start()
    {
        levelTree = new Tree();
        levelTree.InicilizeTree();

        for (int i = 0; i < levelIndex; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            Debug.Log(scene);
        }
    }
}
