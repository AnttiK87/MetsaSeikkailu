using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class KysymysManageri : MonoBehaviour
{
    // Julkiset muuttujat, jotka n‰kyv‰t Inspectorissa
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
        // Alustetaan muuttujat ja kutsutaan kysymysten luontifunktiota
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
    {// Aktivoidaan TietoVisaCanvas ja tarkistetaan vastausten tila
        if (TietoVisaCanvas != null)
        {
            TietoVisaCanvas.SetActive(true);
            kysymysPaneeli.SetActive(true);
            Vaarintxt.SetActive(false);

            // Tarkista, ovatko kaikki vastaukset oikein
            if (KaikkiVastauksetOikein())
            {
                // N‰yt‰ seuraavaSceneNappi, koska kaikki vastaukset ovat oikein
                if (seuraavaSceneNappi != null || seuraavaSceneNappi2 != null)
                {
                    seuraavaSceneNappi.SetActive(true);
                    seuraavaSceneNappi2.SetActive(true);
                }
            }
            else
            {
                // Piilota nappi, jos vastauksia ei ole viel‰ tarpeeksi
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
            // K‰y l‰pi kaikki kysymykset ja tarkista vastaukset
            for (int i = 0; i < kysymys.Vastaukset.Length; i++)
            {
                // K‰ytet‰‰n on onOikein muuttujaa tarkistukseen
                if (!vaihtoehdot[i].GetComponent<VastausScript>().onOikein)
                {
                    // Jos edes yksi vastaus on v‰‰rin, palautetaan false
                    return false;
                }
            }
        }

        // Jos p‰‰stiin t‰nne, kaikki vastaukset olivat oikein
        return true;
    }
    public void SiirrySeuraavaanSceneen()
    {
        TietoVisaCanvas.SetActive(false);
        Destroy(TietoVisaCanvas); //kysymys paneelit tuhotaan

        //Avataan nuoli jolla p‰‰see seuraavaan sceneen
        nuoliSeuraavaScene.SetActive(true);
        kursorinVaihto.AktivoiScript();
    }

    public void ValitseVastaus(int vastausNumero)
    {
        // Valittu vastaus tallennetaan ja kutsutaan oikein-metodia
        valittuVastaus = vastausNumero;
        Debug.Log("Valittu vastaus: " + valittuVastaus);

        oikein();

    
}

    public void oikein()
    {// Tarkista onko vastaus oikein ja p‰ivit‰ pelitila sen mukaan
        Debug.Log("Oikein-metodi kutsuttu");
        if (QnA[nykyinenKysymys].OikeaVastaus == valittuVastaus)
        {
            QnA.RemoveAt(nykyinenKysymys);
            oikeatVastauksetLaskuri++;

            if (QnA.Count > 0)
            {
                Vaarintxt.SetActive(false);
                // p‰ivit‰ nykyinenKysymys uudelleen
                nykyinenKysymys = Random.Range(0, QnA.Count);
                LuoKysymys();
                // Soita oikein ‰‰ni
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
            // V‰‰r‰ vastaus
            Vaarintxt.SetActive(true);
            kysymysPaneeli.SetActive(false);

            //kutsu pelinkestoscripti‰ ja lis‰‰ aikaa v‰‰r‰st‰ vastauksesta
            PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>();
            if (ajastin != null)
            {
                ajastin.LisaaAikaa();
            }

            // Soita "v‰‰r‰" ‰‰ni
            vaarinAani.Play();
        }
        // Varmista, ett‰ Vaarintxt on poissa p‰‰lt‰, vaikka virheilmoituksessa olisi ongelma
       // StartCoroutine(SuljeVaarintxt());
    
}
    //private IEnumerator SuljeVaarintxt()
    //{
    //    yield return new WaitForSeconds(2f);  // Voit muuttaa odotusaikaa tarpeen mukaan
    //    Vaarintxt.SetActive(false);
    //}
    private void TarkistaVoitto()
    {// Tarkistetaan voittoehdot ja p‰ivitet‰‰n pelitila
        Debug.Log("TarkistaVoitto, oikeatVastauksetLaskuri: " + oikeatVastauksetLaskuri);

        if (oikeatVastauksetLaskuri >= 3)
        {
            // N‰yt‰ nappula voiton j‰lkeen
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
            // Piilota nappi, jos vastauksia ei ole viel‰ tarpeeksi
            if (seuraavaSceneNappi != null || seuraavaSceneNappi2 != null)
            {
                seuraavaSceneNappi.SetActive(false);
                seuraavaSceneNappi2.SetActive(false);
            }

            Debug.Log("Ei kaikki vastaukset oikein");
        }
    
}

    void LaitaVastaukset()
    {// Asetetaan vastaukset vaihtoehtoihin
        for (int i = 0; i < vaihtoehdot.Length; i++)
        {// Nollataan onOikein muuttuja jokaiselle vaihtoehdolle
            vaihtoehdot[i].GetComponent<VastausScript>().onOikein = false;
            // Asetetaan vastaus tekstiksi vaihtoehdolle
            vaihtoehdot[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[nykyinenKysymys].Vastaukset[i];

            // Jos vastaus on oikein, p‰ivitet‰‰n onOikein muuttuja
            if (QnA[nykyinenKysymys].OikeaVastaus == i + 1)
            {
                vaihtoehdot[i].GetComponent<VastausScript>().onOikein = true;
            }

            int vastausNumero = i + 1;
            // Poista vanhat kuuntelijat ennen uusien lis‰‰mist‰
            vaihtoehdot[i].GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            // Lis‰‰ uusi kuuntelija
            vaihtoehdot[i].GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ValitseVastaus(vastausNumero));
        }
        
    }

        void LuoKysymys()
        {
        // Piilota virheteksti
        Vaarintxt.SetActive(false);

        // Arvotaan uusi kysymys
        nykyinenKysymys = Random.Range(0, QnA.Count);
        Debug.Log("Uusi kysymys: " + KysymysTxt.text);

        // Asetetaan kysymys tekstiksi
        KysymysTxt.text = QnA[nykyinenKysymys].Kysymys;

        // Asetetaan vastaukset vaihtoehtoihin
        LaitaVastaukset();
    }

    }

