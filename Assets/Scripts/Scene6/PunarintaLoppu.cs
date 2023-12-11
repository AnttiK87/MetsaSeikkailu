using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunarintaLoppu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AvattavaUi;
    public GameObject loppuTelkka;
    public GameObject loppuTelkkaTeksti;

    public void TekstiAuki()
    {
        AvattavaUi.SetActive(true);
    }

    public void LoppuTelkka()
    {
        loppuTelkka.SetActive(true);
        AvattavaUi.SetActive(false);
    }

    public void LoppuTelkkaTeksti()
    {
        loppuTelkkaTeksti.SetActive(true);

    }
}
