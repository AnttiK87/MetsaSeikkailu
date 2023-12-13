using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kysymykset : MonoBehaviour
{
    //Luokka kysymysten näyttämistä varten

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
    public Animator KyselijaPois;
    private List<GameObject> TagattavatObjektit = new List<GameObject>();
    public GameObject[] TagatytObjektit;
    public AudioSource oikeinAani;
    public AudioSource vaarinAani;
    public KursorinVaihto kursorinVaihto;

    //laskuri, että ensimmäinen ui ruutu näytetään vain ensimmäisellä kertaa
    private int counter = 0;

    void Start()
    {
        // Assign game objects to the list
        TagattavatObjektit.Add(objekti1);
        TagattavatObjektit.Add(objekti2);
        TagattavatObjektit.Add(objekti3);
        if (objekti4 != null)
        {
            TagattavatObjektit.Add(objekti4);
        }
    }

    //Objekti johon scripti on liitetty toimimaan nappina
    private void OnMouseUpAsButton()
    {
        //lisätään laskuria
        counter++;

        //jos ekakerta niin näytetään scenen aloitus teksti
        if (panelPre == null && panel1 != null && counter <= 1)
        {
            ActivateObject1();
        }

        //jos aloitusteksti on jo nähty näytetään suoraan kysymykset
        else if (panel1 == null && panel2 != null)
        {
            ActivateObject2();
        }
    }

    //metodi aloitustekstin näytölle
    void ActivateObject1()
    {
        if (panel1 != null)
        {
            panel1.SetActive(true);
            kursorinVaihto.DeaktivoiScript();
        }
    }

    //metodi kysymysten näytölle
    void ActivateObject2()
    {
        if (!panel2.activeSelf && panel2 != null && !GameObject.FindWithTag("Vinkki"))
        {
            kursorinVaihto.DeaktivoiScript();

            //Varmistetaan, että vinkkejä antavat objektit ovat aktiivisina
            objekti1.SetActive(true);
            objekti2.SetActive(true);
            objekti3.SetActive(true);
            objekti4.SetActive(true);

            TagatytObjektit = GameObject.FindGameObjectsWithTag("Vinkkaaja");

            foreach (GameObject obj in TagatytObjektit)
            {
                obj.tag = "Untagged";
            }

            //näytetään canvas jossa kysymykset ovat
            panel2.SetActive(true);
            textVaarin.SetActive(false); //jos vastattu väärin aikaisemmin niin suljetaan värän vastauksen teksti
            
            //näytetään ensimmäinen kysymys
            textKysymys1.SetActive(true);
            textKysymys2.SetActive(false);
        }
    }

    //tämä metodi liitetään ekan ui näytön seuraava nappiin
    public void SeuraavaNappi()
    {
        Destroy(panel1);
        ActivateObject2();
    }

    //tämä metodi liitetään ekan ui näytön vinkki nappeihin
    public void VinkkiNappi()
    {
        panel2.SetActive(false);
        textKysymys1.SetActive(true);
        textKysymys2.SetActive(false);
        foreach (GameObject obj in TagattavatObjektit)
        {
            if (obj != null)
            {
                obj.tag = "Vinkkaaja";
            }
        }
        kursorinVaihto.AktivoiScript();
    }

    ////tämä metodi liitetään ekan ui näytön väärä vastaus nappeihin
    public void VaaraNappi()
    {
        textKysymys1.SetActive(false);
        textKysymys2.SetActive(false);
        textVaarin.SetActive(true);
        vaarinAani.Play();

        //kutsu pelinkestoscriptiä ja lisää aikaa väärästä vastauksesta
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>();
        if (ajastin != null)
        {
            ajastin.LisaaAikaa();
        }

    }

    //tämä metodi liitetään ekan ui näytön ensimmäisen kysymyksen oikea vastaus nappiin
    public void OikeaNappi1()
    {
        textKysymys1.SetActive(false);
        textKysymys2.SetActive(true);
        oikeinAani.Play();
    }

    //tämä metodi liitetään ekan ui näytön toisen kysymyksen oikea vastaus nappiin
    public void OikeaNappi2()
    {
        textKysymys2.SetActive(false);
        textOikein.SetActive(true);
        oikeinAani.Play();

        GameObject suurennuslasi = GameObject.FindWithTag("SuurennusLasi");

        if (suurennuslasi != null)
        {
            suurennuslasi.SetActive(false);
        }
    }

    //tämä metodi liitetään ekan ui loppu näytön eteenpäin nappiin
    public void TerminateCanvas()
    {
        Destroy(panel2); //kysymys paneelit tuhotaan

        //Avataan nuoli jolla pääsee seuraavaan sceneen
        nuoliSeuraavaScene.SetActive(true);

        if (kyselija != null)
        {
            KyselijaPois.SetTrigger("PoisSusi"); //kyselijä poistuu näyttämöltä tarvittaessa
        }

        kursorinVaihto.AktivoiScript();


    }
}
