using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunarintaLoppu : MonoBehaviour
{
    //Muutujat
    public GameObject AvattavaUi;
    public GameObject loppuTelkka;
    public GameObject loppuTelkkaTeksti;
    public Animator Lopetus;
    public KursorinVaihto kursorinVaihto;

    //Punarinnan tekstin aktivointi
    public void TekstiAuki()
    {
        AvattavaUi.SetActive(true);
        kursorinVaihto.DeaktivoiScript();
    }

    //Telkän animaatio
    public void LoppuTelkka()
    {
        loppuTelkka.SetActive(true);
        AvattavaUi.SetActive(false);
    }

    //Telkän teksti
    public void LoppuTelkkaTeksti()
    {
        loppuTelkkaTeksti.SetActive(true);
    }

    //Teksti kiinni ja loppu animaatio
    public void LopetusAnimaatio()
    {
        loppuTelkkaTeksti.SetActive(false);
        Lopetus.SetTrigger("LoppuAnimaatio");
    }
}
