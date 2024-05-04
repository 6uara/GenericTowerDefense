using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{
        [SerializeField] private GameObject panelToActivate;

        public void GoToPanel()
        {
            panelToActivate.SetActive(true);
            gameObject.SetActive(false);
        }
}
