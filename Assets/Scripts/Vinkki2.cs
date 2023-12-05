using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinkki2 : MonoBehaviour
{
    public GameObject panelVinkki2;
    private bool isEnabled = false;

    public static Vinkki2 Vinkki2Instanssi;
    private void Awake()
    {
        if (Vinkki2Instanssi == null)
        {
            Vinkki2Instanssi = this;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (isEnabled)
        {
            //Debug.Log("nappia painettu");
            ActivateObject();
        }
    }

    void ActivateObject()
    {
        if (panelVinkki2 != null)
        {
            panelVinkki2.SetActive(true);
        }
    }

    public void sulje()
    {
        panelVinkki2.SetActive(false);
    }

    public void AktivoiScript()
    {
        // Set the flag to true
        isEnabled = true;

        // Optionally, you can perform additional setup or actions here
    }
}
