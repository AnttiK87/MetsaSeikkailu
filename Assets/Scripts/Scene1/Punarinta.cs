using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class Punarinta : MonoBehaviour
{
    //Avataan ensimm‰inen punarinnan teksti ui

    //muuttujat avattavalle ui canvasille ja seuraavalle ui canvasille
    public GameObject panel;
    public GameObject newPanel;

    //objekti johon scripti on liitetty toimii nappina
    //klikkaamalla kutsutaan metodia joka aktivoi halutun ui objektin
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    //metodi objektin aktivoinnille
    void ActivateObject()
    {
        if (!panel.activeSelf && panel != null)
        {
            panel.SetActive(true);
        }
    }

    //metodi joka liitet‰‰n ui paneelissa olevaan seuraava nappiin
    //tuhoaa nykyisen canvasin ja aktivoi seuraavan
    public void NextText()
    {
        Destroy(panel);
        newPanel.SetActive(true);
        Destroy(GetComponent("Punarinta"));
    }
}
