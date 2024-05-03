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
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void LoadNewScene(string p_sceneName)
    {
        loadingSceneName = p_sceneName;
        SceneManager.LoadScene(loadingSceneName);
    }
}
