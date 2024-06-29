using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheSceneManager : MonoBehaviour
{
    public static TheSceneManager Instance;
    private string loadingSceneName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNewScene(string p_sceneName)
    {
        loadingSceneName = p_sceneName;
        SceneManager.LoadScene(loadingSceneName);
    }
}
