using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheSceneManager : MonoBehaviour
{
    public static TheSceneManager Instance;

    private Tree levelTree;
    public bool isTutorialComplete = false;
    public bool isLevel2Completed = false;

    [Header("Scenes List")]
    [SerializeField] private List<string> sceneList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        levelTree = new Tree();
        levelTree.InicilizeTree();
        levelTree.AddElement(1);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(levelTree.Root());
        Debug.Log(levelTree.Root());
    }

    public void FinishedTutorial()
    {
        levelTree.RightBranch().AddElement(2);
        levelTree.LeftBranch().AddElement(3);
        isTutorialComplete = true;
    }

    public void FinishedLevel2()
    {
        levelTree.RightBranch().RightBranch().AddElement(4);
        isLevel2Completed = true;
    }

    public bool GetTutorialCompleted()
    {
        return isTutorialComplete;
    }

    public bool GetLevel2Completed()
    {
        return isLevel2Completed;
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

    public void LoadBranchByBranch()
    {
        SceneManager.LoadScene(levelTree.RightBranch().RightBranch().Root());
        Debug.Log(levelTree.RightBranch().RightBranch().Root());
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
