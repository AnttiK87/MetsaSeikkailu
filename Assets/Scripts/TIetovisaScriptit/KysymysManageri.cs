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
    public GameObject Vaarintxt;
    private int oikeatVastauksetLaskuri = 0;
    private int valittuVastaus;
    public Canvas SuljeAloitusTervehdys;

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

            // Tarkista, ovatko kaikki vastaukset oikein
            if (KaikkiVastauksetOikein())
            {
                // N‰yt‰ seuraavaSceneNappi, koska kaikki vastaukset ovat oikein
                if (seuraavaSceneNappi != null)
                {
                    seuraavaSceneNappi.SetActive(true);
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
                // Voit esimerkiksi k‰ytt‰‰ VastausScript-luokan onOikein-muuttujaa tarkistukseen
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
        SceneManager.LoadScene("TestScene5");
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
                // P√§ivit√§ nykyinenKysymys uudelleen
                nykyinenKysymys = Random.Range(0, QnA.Count);
                LuoKysymys();
            }
            else
            {
                Vaarintxt.SetActive(false);
                // Kaikki kysymykset on vastattu, tarkista voitto
                TarkistaVoitto();
            }
    }
        else
        {
            // V‰‰r‰ vastaus
            Vaarintxt.SetActive(true);
        }
        // Varmista, ett‰ Vaarintxt on poissa p‰‰lt‰, vaikka virheilmoituksessa olisi ongelma
        StartCoroutine(SuljeVaarintxt());
    
}
    private IEnumerator SuljeVaarintxt()
    {
        yield return new WaitForSeconds(2f);  // Voit muuttaa odotusaikaa tarpeen mukaan
        Vaarintxt.SetActive(false);
    }
    private void TarkistaVoitto()
    {
        Debug.Log("TarkistaVoitto, oikeatVastauksetLaskuri: " + oikeatVastauksetLaskuri);

        if (oikeatVastauksetLaskuri >= 3)
        {
            // N‰yt‰ nappula voiton j‰lkeen
            if (seuraavaSceneNappi != null)
            {
                seuraavaSceneNappi.SetActive(true);
            }
        }
        else
        {
            // Piilota nappi, jos vastauksia ei ole viel‰ tarpeeksi
            if (seuraavaSceneNappi != null)
            {
                seuraavaSceneNappi.SetActive(false);
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

        nykyinenKysymys = Random.Range(0, QnA.Count);
        Debug.Log("Uusi kysymys: " + KysymysTxt.text);
        KysymysTxt.text = QnA[nykyinenKysymys].Kysymys;
        LaitaVastaukset();
    }

    }

