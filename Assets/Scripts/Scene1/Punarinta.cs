using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class Punarinta : MonoBehaviour
{
    //Avataan ensimmäinen punarinnan teksti ui

    //muuttujat avattavalle ui canvasille ja seuraavalle ui canvasille
    public GameObject panel;
    public GameObject newPanel;
    public KursorinVaihto kursorinVaihto;

    //objekti johon scripti on liitetty toimii nappina
    //klikkaamalla kutsutaan metodia joka aktivoi halutun ui objektin
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
        kursorinVaihto.DeaktivoiScript();
    }

    //metodi objektin aktivoinnille
    void ActivateObject()
    {
        if (!panel.activeSelf && panel != null)
        {
            panel.SetActive(true);
            
        }
    }

    //metodi joka liitetään ui paneelissa olevaan seuraava nappiin
    //tuhoaa nykyisen canvasin ja aktivoi seuraavan
    public void NextText()
    {
        Destroy(panel);
        newPanel.SetActive(true);
        Destroy(GetComponent("Punarinta"));
    }
}
