using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TheSceneManager sceneManager;
    public Button button1;
    public Button button2;
    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TheSceneManager>();
        if (sceneManager.GetTutorialCompleted())
        {
            button1.interactable = true;
            button2.interactable = true;
        }
        else
        {
            button1.interactable = false;
            button2.interactable = false;
        }
    }

    public void LoadLevelByBranch(bool isRight)
    {
        sceneManager.LoadBranch(isRight);
    }

    public void LoadFirstLevel()
    {
        sceneManager.LoadFirstLevel();
    }
}
