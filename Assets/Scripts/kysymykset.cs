using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kysymykset : MonoBehaviour
{
    //Luokka kysymysten n‰ytt‰mist‰ varten

    //muuttujat
    public GameObject panelPre;
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
    public GameObject kyselija;

    //laskuri, ett‰ ensimm‰inen ui ruutu n‰ytet‰‰n vain ensimm‰isell‰ kertaa
    private int counter = 0;

    //Objekti johon scripti on liitetty toimimaan nappina
    private void OnMouseUpAsButton()
    {
        //lis‰t‰‰n laskuria
        counter++;

        //jos ekakerta niin n‰ytet‰‰n scenen aloitus teksti
        if (panelPre == null && panel1 != null && counter <= 1)
        {
            ActivateObject1();
        }

        //jos aloitusteksti on jo n‰hty n‰ytet‰‰n suoraan kysymykset
        else if (panel1 == null && panel2 != null)
        {
            ActivateObject2();
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

    //metodi kysymysten n‰ytˆlle
    void ActivateObject2()
    {
        if (!panel2.activeSelf && panel2 != null)
        {
            Aktivoi(); //aktivoidaan vikki scripti

            //Varmistetaan, ett‰ vinkkej‰ antavat objektit ovat aktiivisina
            objekti1.SetActive(true);
            objekti2.SetActive(true);
            objekti3.SetActive(true);
            objekti4.SetActive(true);
               
            //n‰ytet‰‰n canvas jossa kysymykset ovat
            panel2.SetActive(true);
            textVaarin.SetActive(false); //jos vastattu v‰‰rin aikaisemmin niin suljetaan v‰r‰n vastauksen teksti
            
            //n‰ytet‰‰n ensimm‰inen kysymys
            textKysymys1.SetActive(true);
            textKysymys2.SetActive(false);
        }
    }

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn seuraava nappiin
    public void SeuraavaNappi()
    {
        Destroy(panel1);
        ActivateObject2();
    }

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn vinkki nappeihin
    public void VinkkiNappi()
    {
        panel2.SetActive(false);
        textKysymys1.SetActive(true);
        textKysymys2.SetActive(false);
    }

    ////t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn v‰‰r‰ vastaus nappeihin
    public void VaaraNappi()
    {
        textKysymys1.SetActive(false);
        textKysymys2.SetActive(false);
        textVaarin.SetActive(true);
    }

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn ensimm‰isen kysymyksen oikea vastaus nappiin
    public void OikeaNappi1()
    {
        textKysymys1.SetActive(false);
        textKysymys2.SetActive(true);
    }

    //t‰m‰ metodi liitet‰‰n ekan ui n‰ytˆn toisen kysymyksen oikea vastaus nappiin
    public void OikeaNappi2()
    {
        textKysymys2.SetActive(false);
        textOikein.SetActive(true);
    }

    //t‰m‰ metodi liitet‰‰n ekan ui loppu n‰ytˆn eteenp‰in nappiin
    public void TerminateCanvas()
    {
        Deaktivoi(); //vinkki objektit deaktivoidaan

        Destroy(panel2); //kysymys paneelit tuhotaan

        //Avataan nuoli jolla p‰‰see seuraavaan sceneen
        nuoliSeuraavaScene.SetActive(true);

        if (kyselija != null)
            {
                kyselija.SetActive(false); //kyselij‰ poistuu n‰ytt‰mˆlt‰ tarvittaessa
        }
        
 
    }

    //Kutsutaan vinkki luokkan metodia ja aktivoidaan vinkkien n‰yttˆ
    void Aktivoi()
    {
        Vinkki.VinkkiInstanssi.AktivoiScript();
    }

    //Kutsutaan vinkki luokkan metodia ja deaktivoidaan vinkkien n‰yttˆ
    void Deaktivoi()
    {
        Vinkki.VinkkiInstanssi.DeaktivoiScript();
    }
}
