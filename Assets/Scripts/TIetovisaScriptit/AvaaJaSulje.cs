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

    //objekti johon scripti on liitetty toimii nappina
    //klikkaamalla kutsutaan metodia joka aktivoi halutun ui objektin
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateVinkki1();
    }

    //Avataan vinkki
    void ActivateVinkki1()
    {
            //Jos vinkki on olemassa/m‰‰ritetty ¥ja muita vinkkej‰ ei ole auki
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
