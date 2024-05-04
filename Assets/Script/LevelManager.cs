using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform[] path;
    public Transform StartPoint;
    [SerializeField]private int availableTower;
    private void Awake()
    {
        main = this;
    }

    public bool available()
    {
        if(availableTower > 0){
            return true;
        }else{
            return false;
        }
    }

    public void aument(){availableTower ++;}
    public void decrease(){availableTower --;}
}
