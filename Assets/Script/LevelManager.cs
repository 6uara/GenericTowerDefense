using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instancie;
    public Transform[] path;
    public Transform[] path2;
    public Transform StartPoint;
    public Transform StartPoint2;
    [SerializeField] private int availableTower;

    private Tree levelTree;


    private void Awake()
    {
        if (Instancie != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instancie = this;
        }
    }

    private void Start()
    {
        levelTree = new Tree();
        levelTree.InicilizeTree();
    }



    public bool available()
    {
        if (availableTower > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void aument()
    {
        availableTower ++;
    }
    public void decrease()
    {
        availableTower --;
    }
}
