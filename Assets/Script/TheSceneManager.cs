using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheSceneManager : MonoBehaviour
{
    public static TheSceneManager Instance;

    private Tree levelTree;
    private bool isTutorialComplete = false;

    [Header("Scenes List")]
    [SerializeField] private List<string> sceneList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Application.targetFrameRate = 300;
    }

    private void Start()
    {
        levelTree = new Tree();
        levelTree.InicilizeTree();
        levelTree.AddElement(0);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(levelTree.Root());
        Debug.Log(levelTree.Root());
    }

    public void FinishedTutorial()
    {
        levelTree.RightBranch().AddElement(1);
        levelTree.LeftBranch().AddElement(2);
        isTutorialComplete = true;
    }

    public bool GetTutorialCompleted()
    {
        return isTutorialComplete;
    }

    public void LoadBranch(bool isRight)
    {
        if (levelTree.RightBranch().EmptyTree() || levelTree.LeftBranch().EmptyTree())
        {
            Debug.Log("You must complete tutorial!");
        }
        else
        {
            if (isRight)
            {
                SceneManager.LoadScene(levelTree.RightBranch().Root());
                Debug.Log(levelTree.RightBranch().Root());
            }
            else
            {
                SceneManager.LoadScene(levelTree.LeftBranch().Root());
                Debug.Log(levelTree.LeftBranch().Root());
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
