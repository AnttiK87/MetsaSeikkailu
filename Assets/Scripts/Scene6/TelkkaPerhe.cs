using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TelkkaPerhe : MonoBehaviour
{
    public GameObject panel;
    public GameObject telkka1;
    public GameObject telkka2;
    public GameObject telkkaUinti;
    public GameObject telkkaUintiPois;
    public GameObject telkkaPerhePois;
    public GameObject telkkaPerhe;
    public GameObject punarintaAktivointi;
    public KursorinVaihto kursorinVaihto;

    private int counter = 0;

    private void OnMouseUpAsButton()
    {
        counter++;

        if (panel != null && counter <= 1)
        {
            ActivateObject();
        }
        else
        {
            ActivateObject2();
        }
    }

    //Ui ruutu näkymään
    void ActivateObject()
    {
        if (!panel.activeSelf && panel != null)
        {
            panel.SetActive(true);
            kursorinVaihto.DeaktivoiScript();
        }
    }

    //telkkäperhe pois animaatio käyntiin
    void ActivateObject2()
    {
        telkkaUintiPois.SetActive(false);
        telkkaPerhe.SetActive(false);
        telkkaPerhePois.SetActive(true);
        punarintaAktivointi.SetActive(true);
    }

    //Ui kiinni ja telkkä perheen luo
    public void DeactivateObject()
    {
        panel.SetActive(false);
        Destroy(panel);
        telkka1.SetActive(false);
        telkka2.SetActive(true);
        telkkaUinti.SetActive(true);
        kursorinVaihto.AktivoiScript();
    }
}
