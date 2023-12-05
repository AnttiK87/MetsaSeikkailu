using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinkki : MonoBehaviour
{
    public GameObject panelVinkki1;

    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateVinkki1();
    }

    void ActivateVinkki1()
    {
        if (panelVinkki1 != null)
        {
            panelVinkki1.SetActive(true);
        }
    }

    public void suljeVinkki1()
    {
        panelVinkki1.SetActive(false);
    }
}
