using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Punarinta : MonoBehaviour
{
    public GameObject panel;
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
}
