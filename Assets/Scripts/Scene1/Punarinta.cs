using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Punarinta : MonoBehaviour
{
    public GameObject panel;
    public GameObject txt1;
    public GameObject txt2;
    public GameObject newPanel;
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    void ActivateObject()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void NextText()
    {
        if (txt1 != null)
        {
            txt1.SetActive(false);
            txt2.SetActive(true);
        }
    }
    public void TerminateCanvas()
    {
        Destroy(panel);
        newPanel.SetActive(true);
    }
}
