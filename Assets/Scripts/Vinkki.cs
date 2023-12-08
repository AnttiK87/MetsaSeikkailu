using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinkki : MonoBehaviour
{
    //Luokka vinkkien n‰ytt‰mist‰ varten

    //muuttujat
    public GameObject panelVinkki1;
    public GameObject panelVinkki2;
    public GameObject panelVinkki3;
    public GameObject panelVinkki4;
    public GameObject Kysymykset;
    private string klikattu;
    private bool isEnabled = false;

    //Aktivoidana vinkki luokka, ett‰ sit‰ voidaan kutsua kysymykset luokasta
    public static Vinkki VinkkiInstanssi;
    private void Awake()
    {
        if (VinkkiInstanssi == null)
        {
            VinkkiInstanssi = this;
        }
    }

    //Kuunnellaan klikataanko jotain vinkki objekteista
    private void Update()
    {
        
            //hiit‰ on klikattu
            if (Input.GetMouseButtonDown(0))
            {
                // M‰‰ritet‰‰n klikattiinko objektia ja mik‰ se oli
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                //Jos osui objektiin
                if (Physics.Raycast(ray, out hit))
                {
                    // Haetaan objektille oleva tagi 
                    if (hit.collider.gameObject.tag != null)
                    {
                        //tallennetaan tagi muuttujaan
                        klikattu = hit.collider.gameObject.tag;

                        //Debug.Log("Klikatun objektin tagi: " + klikattu);

                        //kutsutaan metodia jolla n‰ytet‰‰n vinkki ja vied‰‰n metodiin
                        //klikatub tagin nimi, ett‰ osataan avata haluttu vinkki
                        if (isEnabled)
                        {
                            ActivateVinkki(klikattu);
                        }
                    }
                }
            }
       
    }

    //metodi vinkin n‰ytt‰mist‰ varten
    void ActivateVinkki(string klikattuObjekti)
    {
        //katsotaan onko kysymys ruutu auki jos on niin ei avata vinkki‰ p‰‰lle
            //ps. Vaatii paljon drag droppia unityn puolella.
        if (!Kysymykset.activeSelf && Kysymykset != null && !panelVinkki1.activeSelf && !panelVinkki2.activeSelf && !panelVinkki3.activeSelf && !panelVinkki4.activeSelf)
        {
            //tarkastetaan mij‰ vinkki n‰ytet‰‰n.
            //ps. Vaatii paljon drag droppia unityn puolella.
            //liitett‰v‰ kaikkiin vinkki objekteihin ja kaikkiin on anettava kaikki vinkki ui canvasit
             if (klikattuObjekti.Equals("Vinkki1"))
            {
                panelVinkki1.SetActive(true);
            }
            else if (klikattuObjekti.Equals("Vinkki2"))
            {
                panelVinkki2.SetActive(true);
            }
            else if (klikattuObjekti.Equals("Vinkki3"))
            {
                panelVinkki3.SetActive(true);
            }
            else if (klikattuObjekti.Equals("Vinkki4"))
            {
                panelVinkki4.SetActive(true);
            }
        }
    }

    //Suljetaan vinkki. t‰m‰ liitet‰‰n sulje nappeihin unityss‰
    public void suljeVinkki1()
    {
        panelVinkki1.SetActive(false);
        panelVinkki2.SetActive(false);
        panelVinkki3.SetActive(false);
        panelVinkki4.SetActive(false);
    }

    //Aktivoidaan scripti. T‰t‰ kutsutaan kysymyksiss‰
    public void AktivoiScript()
    {
        
        isEnabled = true;

        
    }

    //Deaktivoidaan scripti. T‰t‰ kutsutaan kysymyksiss‰
    public void DeaktivoiScript()
    {
        
        isEnabled = false;

        
    }
}
