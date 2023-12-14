using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaJaSulje : MonoBehaviour
{
    //Vinkkejen avaamiseen ja sulkemiseen

    //muuttujat
    public GameObject VinkkiCanvas;
    public AudioSource vinkkiAani;
    private string klikattu;
    public KursorinVaihto kursorinVaihto;

    //Vinkit pois p‰‰lt‰ alussa
    public void Start()
    {
        if (VinkkiCanvas != null)
        {
            VinkkiCanvas.SetActive(false);
        }
    }

    //Osalla objekteista on kaksi teht‰v‰‰, joten tagilla tarkastus onko objekti jo vinkki "tilassa"
    private void OnMouseUpAsButton()
    {
        // M‰‰ritet‰‰n klikattiinko objektia ja mik‰ se oli
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

    //N‰ytet‰‰n vinkki
    void ActivateVinkki1()
    {

            if (VinkkiCanvas != null && !GameObject.FindWithTag("Vinkki"))
            {
                VinkkiCanvas.SetActive(true);
                vinkkiAani.Play();
                kursorinVaihto.DeaktivoiScript();
        }
 
   
    }

    //Suljetaan vinkki
    public void suljeVinkki1()
    {
        VinkkiCanvas.SetActive(false);
        kursorinVaihto.AktivoiScript();

    }
}
