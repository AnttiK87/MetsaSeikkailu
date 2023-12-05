using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Kyselija : MonoBehaviour
{
    public GameObject kyselija;

    private void OnMouseUpAsButton()
    {
        Debug.Log("nappia painettu");
        ActivateObject();
    }

    void ActivateObject()
    {
        if (kyselija != null)
        {

            kyselija.SetActive(true);
        }
    }
}
