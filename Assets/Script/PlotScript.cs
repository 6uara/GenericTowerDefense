using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    //private void OnMouseDown()
    //{
    //    if (tower != null)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        if(LevelManager.Instancie.available())
    //        {
    //            GameObject towerToBuild = BuildManager.Instance.GetSelectedTower();
    //            tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    //            LevelManager.Instancie.decrease();
    //        }
    //    }
    //}
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (tower != null)
            {
                return;
            }
            else
            {
                if (LevelManager.Instancie.available())
                {
                    GameObject towerToBuild = BuildManager.Instance.GetSelectedTower(0);
                    tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
                    LevelManager.Instancie.decrease();
                }
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (tower != null)
            {
                return;
            }
            else
            {
                if (LevelManager.Instancie.available())
                {
                    GameObject towerToBuild = BuildManager.Instance.GetSelectedTower(1);
                    tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
                    LevelManager.Instancie.decrease();
                }
            }
        }
    }
}
