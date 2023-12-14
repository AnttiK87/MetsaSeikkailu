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
    public GameObject objekti4;
    public GameObject vinkki1;
    public GameObject vinkki2;
    public GameObject vinkki3;
    public GameObject vinkki4;
    public GameObject kyselija;
    public KysymysManageri kysymysManageri; //kutsutaan luokkaa KysymysManageri
    public KursorinVaihto kursorinVaihto; //kutsutaan luokkaa KursorinVaihto



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
            //Kutsutaan kursorin vaihdon pois ottamista
            kursorinVaihto.DeaktivoiScript();

            //yhdess‰ sceness‰ vaan nelj‰ vinkki‰ joten siksi n‰in
            if (vinkki4 == null)
            {
                //Vinkki objektit pois p‰‰lt‰, ett‰ eiv‰t aukea yht‰aikaa muun ui:n kanssa
                if (!vinkki1.activeSelf && !vinkki2.activeSelf && !vinkki3.activeSelf)
                {
                    objekti1.SetActive(false);
                    objekti2.SetActive(false);
                    objekti3.SetActive(false);

                    //n‰ytet‰‰n kysymykset
                    kysymysManageri.AktivoiTietoVisaCanvas();
                } 
            }
            else
            {
                if (!vinkki1.activeSelf && !vinkki2.activeSelf && !vinkki3.activeSelf)
                {
                    objekti1.SetActive(false);
                    objekti2.SetActive(false);
                    objekti3.SetActive(false);
                    objekti4.SetActive(false);

                    kysymysManageri.AktivoiTietoVisaCanvas();
                }        
            }
        }
    }

    //metodi aloitustekstin n‰ytˆlle
    void ActivateObject1()
    {
        if (panel1 != null)
        {
            panel1.SetActive(true);

            //osoittimen vaihto poisp‰‰lt‰
            kursorinVaihto.DeaktivoiScript();
        }
    }
 

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn seuraava nappiin
    public void SeuraavaNappi()
    {
        Destroy(panel1);
        kysymysManageri.AktivoiTietoVisaCanvas();

}

    //t‰m‰ metodi liitet‰‰n ui n‰ytˆn vinkki nappeihin/nappiin
    public void VinkkiNappi()
    {
        panel2.SetActive(false);
        objekti1.SetActive(true);
        objekti2.SetActive(true);
        objekti3.SetActive(true);
        if (objekti4 != null)
        {
            objekti4.SetActive(true);
        }

        //ui menee kinni joten kursorin vaihto aktivoidaan
        kursorinVaihto.AktivoiScript();
    }
}

