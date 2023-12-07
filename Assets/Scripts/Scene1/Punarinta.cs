using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class Punarinta : MonoBehaviour
{
    public GameObject panel;
    public GameObject newPanel;
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    void ActivateObject()
    {
        if (!panel.activeSelf && panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void NextText()
    {
        Destroy(panel);
        newPanel.SetActive(true);
    }
}
