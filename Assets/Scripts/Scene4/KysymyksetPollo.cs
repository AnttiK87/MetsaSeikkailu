using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KysymyksetPollo : MonoBehaviour
{
    //Luokka kysymysten n‰ytt‰mist‰ varten

    //muuttujat
    public GameObject panel1;
    public GameObject panel2;
    public GameObject objekti1;
    public GameObject objekti2;
    public GameObject objekti3;
    public GameObject vinkki1;
    public GameObject vinkki2;
    public GameObject vinkki3;
    public GameObject kyselija;
    public KysymysManageri kysymysManageri;


    //laskuri, ett‰ ensimm‰inen ui ruutu n‰ytet‰‰n vain ensimm‰isell‰ kertaa
    private int counter = 0;

    //Objekti johon scripti on liitetty toimimaan nappina
    private void OnMouseUpAsButton()
    {
        //lis‰t‰‰n laskuria
        counter++;

        //jos ekakerta niin n‰ytet‰‰n scenen aloitus teksti
        if (panel1 != null && counter <= 1)
        {
            ActivateObject1();
        }

        //jos aloitusteksti on jo n‰hty n‰ytet‰‰n suoraan kysymykset
        else if (panel1 == null && kysymysManageri != null)
        {
            if (!vinkki1.activeSelf && !vinkki2.activeSelf && !vinkki3.activeSelf)
            {
                objekti1.SetActive(false);
                objekti2.SetActive(false);
                objekti3.SetActive(false);
                kysymysManageri.AktivoiTietoVisaCanvas();
            }
            
        }
    }

    //metodi aloitustekstin n‰ytˆlle
    void ActivateObject1()
    {
        if (panel1 != null)
        {
            panel1.SetActive(true);
        }
    }
 

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn seuraava nappiin
    public void SeuraavaNappi()
    {
        Destroy(panel1);
        kysymysManageri.AktivoiTietoVisaCanvas();

}

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn vinkki nappeihin
    public void VinkkiNappi()
    {
        panel2.SetActive(false);
        objekti1.SetActive(true);
        objekti2.SetActive(true);
        objekti3.SetActive(true);
    }
}

