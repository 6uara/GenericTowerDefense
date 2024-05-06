using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropSc : MonoBehaviour
{
    private void OnMouseDown()
    {
        LevelManager.Instancie.aument();
        Destroy(gameObject);
    }
}
