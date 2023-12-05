using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kysymykset : MonoBehaviour
{
    public GameObject panel;
    public GameObject textKysymys1;
    public GameObject textKysymys2;
    public GameObject textVaarin;
    public GameObject textOikein;
    public GameObject kivi;
    public GameObject nuoli;

    private int counter;
    

    private void OnMouseUpAsButton()
    {
        kivi.SetActive(true);
        textVaarin.SetActive(false);
        Aktivoi();
        counter++;

        if (counter > 1) 
        {
            //Debug.Log("nappia painettu");
            ActivateObject();
        }
    }

    void ActivateObject()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
    public void VinkkiNappi()
    {
        panel.SetActive(false);
        textKysymys1.SetActive(true);
        textKysymys2.SetActive(false);
    }

    public void VaaraNappi()
    {
        textKysymys1.SetActive(false);
        textKysymys2.SetActive(false);
        textVaarin.SetActive(true);
    }

    public void OikeaNappi1()
    {
        textKysymys1.SetActive(false);
        textKysymys2.SetActive(true);
    }

    public void OikeaNappi2()
    {
        textKysymys2.SetActive(false);
        textOikein.SetActive(true);
    }

    public void TerminateCanvas()
    {
        Destroy(panel);
        nuoli.SetActive(true);
    }

    void Aktivoi()
    {
        Vinkki2.Vinkki2Instanssi.AktivoiScript();
    }
}
