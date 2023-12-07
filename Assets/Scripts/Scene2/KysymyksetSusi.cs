using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KysymyksetSusi : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject textKysymys1;
    public GameObject textKysymys2;
    public GameObject textVaarin;
    public GameObject textOikein;
    public GameObject objekti1;
    public GameObject objekti2;
    public GameObject objekti3;
    public GameObject objekti4;
    public GameObject nuoliSeuraavaScene;
    public GameObject Kyselij�;

    private int counter = 0;


    private void OnMouseUpAsButton()
    {
        
        counter++;

        if (panel1 != null  && counter <= 1)
        {
            ActivateObject1();
        }
        
        else if (panel1 == null && panel2 != null)
        {
            ActivateObject2();
        }
    }

    void ActivateObject1()
    {
        if (panel1 != null)
        {
            panel1.SetActive(true);
            objekti1.SetActive(true);
            objekti2.SetActive(true);
            objekti3.SetActive(true);
            objekti4.SetActive(true);
            textVaarin.SetActive(false);
        }
    }
    void ActivateObject2()
    {
        if (!panel2.activeSelf && panel2 != null)
        {
            Aktivoi();
            panel2.SetActive(true);
            textVaarin.SetActive(false);
            textKysymys1.SetActive(true);
            textKysymys2.SetActive(false);
        }
    }

    public void SeuraavaNappi()
    {
        Destroy(panel1);
        ActivateObject2();
    }
    public void VinkkiNappi()
    {
        panel2.SetActive(false);
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
        Deaktivoi();
 
        Destroy(panel2);
        
        nuoliSeuraavaScene.SetActive(true);
        Kyselij�.SetActive(false);
    }

    void Aktivoi()
    {
        Vinkki.VinkkiInstanssi.AktivoiScript();
    }

    void Deaktivoi()
    {
        Vinkki.VinkkiInstanssi.DeaktivoiScript();
    }
}

