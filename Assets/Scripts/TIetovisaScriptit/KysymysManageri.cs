using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class KysymysManageri : MonoBehaviour
{
    public List<KysymyksetVastaukset> QnA;
    public GameObject[] vaihtoehdot;
    public int nykyinenKysymys;
    public GameObject TietoVisaCanvas;
    public GameObject seuraavaSceneNappi;
    public GameObject seuraavaSceneNappi2;
    public GameObject Vaarintxt;
    private int oikeatVastauksetLaskuri = 0;
    private int valittuVastaus;
    public Canvas SuljeAloitusTervehdys;
    public AudioSource oikeinAani;
    public AudioSource vaarinAani;
    public GameObject nuoliSeuraavaScene;
    public GameObject kysymysPaneeli;
    public GameObject SuurennusLasi;
    public KursorinVaihto kursorinVaihto;

    public Text KysymysTxt;

    private void Start()
    {
        
        oikeatVastauksetLaskuri = 0;
        LuoKysymys();

        // Piilotetaan canvas alussa
        if (TietoVisaCanvas != null)
        {
            TietoVisaCanvas.SetActive(false);
        }

        // Piilotetaan seuraavaSceneNappi alussa

        seuraavaSceneNappi.SetActive(false);
        

        Vaarintxt.SetActive(false);

    }
    public void SuljeAloitusCanvas()
    {
        // Sulje canvas
        SuljeAloitusTervehdys.gameObject.SetActive(false);
    }

    public void AktivoiTietoVisaCanvas()
    {
        if (TietoVisaCanvas != null)
        {
            TietoVisaCanvas.SetActive(true);
            kysymysPaneeli.SetActive(true);
            Vaarintxt.SetActive(false);

            // Tarkista, ovatko kaikki vastaukset oikein
            if (KaikkiVastauksetOikein())
            {
                // N�yt� seuraavaSceneNappi, koska kaikki vastaukset ovat oikein
                if (seuraavaSceneNappi != null || seuraavaSceneNappi2 != null)
                {
                    seuraavaSceneNappi.SetActive(true);
                    seuraavaSceneNappi2.SetActive(true);
                }
            }
            else
            {
                // Piilota nappi, jos vastauksia ei ole viel� tarpeeksi
                if (seuraavaSceneNappi != null)
                {
                    seuraavaSceneNappi.SetActive(false);
                }
            }
        }
    }
    private bool KaikkiVastauksetOikein()
    {
        foreach (KysymyksetVastaukset kysymys in QnA)
        {
            // K�y l�pi kaikki kysymykset ja tarkista vastaukset
            for (int i = 0; i < kysymys.Vastaukset.Length; i++)
            {
                // Voit esimerkiksi k�ytt�� VastausScript-luokan onOikein-muuttujaa tarkistukseen
                if (!vaihtoehdot[i].GetComponent<VastausScript>().onOikein)
                {
                    // Jos edes yksi vastaus on v��rin, palautetaan false
                    return false;
                }
            }
        }

        // Jos p��stiin t�nne, kaikki vastaukset olivat oikein
        return true;
    }
    public void SiirrySeuraavaanSceneen()
    {
        TietoVisaCanvas.SetActive(false);
        Destroy(TietoVisaCanvas); //kysymys paneelit tuhotaan

        //Avataan nuoli jolla p��see seuraavaan sceneen
        nuoliSeuraavaScene.SetActive(true);
        kursorinVaihto.AktivoiScript();
    }

    public void ValitseVastaus(int vastausNumero)
    {

        valittuVastaus = vastausNumero;
        Debug.Log("Valittu vastaus: " + valittuVastaus);

        oikein();

    
}

    public void oikein()
    {
        Debug.Log("Oikein-metodi kutsuttu");
        if (QnA[nykyinenKysymys].OikeaVastaus == valittuVastaus)
        {
            QnA.RemoveAt(nykyinenKysymys);
            oikeatVastauksetLaskuri++;

            if (QnA.Count > 0)
            {
                Vaarintxt.SetActive(false);
                // Päivitä nykyinenKysymys uudelleen
                nykyinenKysymys = Random.Range(0, QnA.Count);
                LuoKysymys();
                // Soita "oikea" ��ni
                oikeinAani.Play();
            }
            else
            {
                Vaarintxt.SetActive(false);
                // Kaikki kysymykset on vastattu, tarkista voitto
                TarkistaVoitto();
                oikeinAani.Play();
            }
    }
        else
        {
            // V��r� vastaus
            Vaarintxt.SetActive(true);
            kysymysPaneeli.SetActive(false);

            //kutsu pelinkestoscripti� ja lis�� aikaa v��r�st� vastauksesta
            PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>();
            if (ajastin != null)
            {
                ajastin.LisaaAikaa();
            }

            // Soita "v��r�" ��ni
            vaarinAani.Play();
        }
    
}

    private void TarkistaVoitto()
    {
        Debug.Log("TarkistaVoitto, oikeatVastauksetLaskuri: " + oikeatVastauksetLaskuri);

        if (oikeatVastauksetLaskuri >= 3)
        {
            // N�yt� nappula voiton j�lkeen
            if (seuraavaSceneNappi != null || seuraavaSceneNappi2 != null)
            {
                seuraavaSceneNappi.SetActive(true);
                seuraavaSceneNappi2.SetActive(true);
                kysymysPaneeli.SetActive(false);
                SuurennusLasi.SetActive(false);
            }
        }
        else
        {
            // Piilota nappi, jos vastauksia ei ole viel� tarpeeksi
            if (seuraavaSceneNappi != null || seuraavaSceneNappi2 != null)
            {
                seuraavaSceneNappi.SetActive(false);
                seuraavaSceneNappi2.SetActive(false);
            }

            Debug.Log("Ei kaikki vastaukset oikein");
        }
    
}

    void LaitaVastaukset()
    {
        for (int i = 0; i < vaihtoehdot.Length; i++)
        {
            vaihtoehdot[i].GetComponent<VastausScript>().onOikein = false;
            vaihtoehdot[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[nykyinenKysymys].Vastaukset[i];

            if (QnA[nykyinenKysymys].OikeaVastaus == i + 1)
            {
                vaihtoehdot[i].GetComponent<VastausScript>().onOikein = true;
            }

            int vastausNumero = i + 1;
            // Poista vanhat kuuntelijat ennen uusien lis��mist�
            vaihtoehdot[i].GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            // Lis�� uusi kuuntelija
            vaihtoehdot[i].GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ValitseVastaus(vastausNumero));
        }
        
    }

        void LuoKysymys()
        {
        // Piilota virheteksti
        Vaarintxt.SetActive(false);

        nykyinenKysymys = Random.Range(0, QnA.Count);
        Debug.Log("Uusi kysymys: " + KysymysTxt.text);
        KysymysTxt.text = QnA[nykyinenKysymys].Kysymys;
        LaitaVastaukset();
    }

    }

