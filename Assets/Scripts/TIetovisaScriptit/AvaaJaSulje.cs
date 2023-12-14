using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaJaSulje : MonoBehaviour
{
    //muuttujat
    public GameObject VinkkiCanvas;
    public AudioSource vinkkiAani;
    private string klikattu;

    public void Start()
    {
        //vinkit piiloon aloituksessa
        if (VinkkiCanvas != null)
        {
            VinkkiCanvas.SetActive(false);
        }
    }

    //Osalla objekteista on kaksi teht�v��. Esim telk�np�ntt� muuttuu vinkki objektiksi sitten kun alun animaatiot on n�ytetty
    //Vinkki objekteille annetaan tagiSiksi t�m� on tehty v�h
    private void OnMouseUpAsButton()
    {
        // M��ritet��n klikattiinko objektia ja mik� se oli
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Jos osui objektiin
        if (Physics.Raycast(ray, out hit))
        {
            // Haetaan objektille oleva tagi 
            if (hit.collider.gameObject.tag != null)
            {
                //tallennetaan tagi muuttujaan
                klikattu = hit.collider.gameObject.tag;
            }

            if (klikattu.Equals("Vinkkaaja"))
            {
                //Debug.Log("nappia painettu");
                ActivateVinkki1();
            }
        }
    }

    //Avataan vinkki
    void ActivateVinkki1()
    {

            if (VinkkiCanvas != null && !GameObject.FindWithTag("Vinkki"))
            {
                VinkkiCanvas.SetActive(true);
                vinkkiAani.Play();
        }
 
   
    }

    //suljetaan vinkki
    public void suljeVinkki1()
    {
        VinkkiCanvas.SetActive(false);
    }
}
