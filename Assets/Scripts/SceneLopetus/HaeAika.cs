using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HaeAika : MonoBehaviour
{
    public TextMeshProUGUI aikaTeksti;  // teksti johon tulee aika
    public TextMeshProUGUI enn‰tysAikaTeksti;  // teksti johon tulee enn‰tysaika

    void Start() 
    {
        if (aikaTeksti == null) // jos aikaTeksti ei ole asetettu Inspectorissa
        {
            print("aikaTeksti not assigned in the Inspector"); // annetaan error
            return;
        }

        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsit‰‰n pelin kesto scripti ja luodaan siit‰ olio

        if (ajastin != null) // jos pelin kesto scripti lˆytyy
        {
            int minuutit = ajastin.HaeKuluneetMinuutit(); // haetaan kuluneet minuutit
            int sekunnit = ajastin.HaeKuluneetSekunnit(); // haetaan kuluneet sekunnit
            aikaTeksti.text = "Seikkailusi kesto: " + minuutit + " min " + sekunnit + " s"; // asetetaan tekstiin kulunut aika

            NollaaEnn‰tysAika(); // kutsutaan metodia joka nollaa enn‰tysajan
            P‰ivit‰Enn‰tysAika(minuutit, sekunnit);// kutsutaan enn‰tysajan p‰ivitys metodia
        }
        else
        {
            print("PelinKestoScripti not found"); // jos pelin kesto scripti‰ ei lˆydy annetaan error
        }
        Debug.Log("Tallennettu enn‰tysaika: " + PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue));
    }

    void P‰ivit‰Enn‰tysAika(int minuutit, int sekunnit) // metodi p‰ivitt‰‰ enn‰tysajan
    {
        float nykyinenAika = minuutit * 60 + sekunnit; // lasketaan nykyinen aika taas sekunneiksi
        float ennatysAika = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan vanha enn‰tysaika playerprefsist‰ ja jos sit‰ ei ole asetettu niin k‰ytet‰‰n float.MaxValue

        if (nykyinenAika < ennatysAika) // jos nykyinen aika on pienempi kuin vanha enn‰tysaika
        {
            PlayerPrefs.SetFloat("EnnatysAika", nykyinenAika); // tallennetaan uusi enn‰tysaika
            PlayerPrefs.Save(); // tallennetaan v‰littˆm‰sti
        }

        N‰yt‰Enn‰tysAika(); // kutsutaan metodia joka n‰ytt‰‰ enn‰tysajan
    }

    void N‰yt‰Enn‰tysAika() // metodi n‰ytt‰‰ enn‰tysajan
    {
        if (enn‰tysAikaTeksti != null) // jos ennatysAikaTeksti on asetettu
        {
            float ennatysAika = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan enn‰tysaika
            if (ennatysAika != float.MaxValue) // jos enn‰tysaika ei ole float.MaxValue eli se on asetettu
            {
                int ennatysMinuutit = (int)(ennatysAika / 60); // lasketaan minuutit jakamalla enn‰tysaika 60:ll‰
                int ennatysSekunnit = (int)(ennatysAika % 60); // lasketaan sekunnit jakamalla enn‰tysaika 60:ll‰ ja ottamalla jakoj‰‰nnˆs
                enn‰tysAikaTeksti.text = "Nopein aika: " + ennatysMinuutit + " min " + ennatysSekunnit + " s"; // asetetaan tekstiin enn‰tysaika
            }
            else // jos enn‰tysaika on float.MaxValue eli sit‰ ei ole asetettu
            {
                enn‰tysAikaTeksti.text = "Nopein aika: - "; // asetetaan tekstiin -
            }
        }
    }

    public void NollaaEnn‰tysAika() // metodi nollaa enn‰tysajan
    {
        PlayerPrefs.DeleteKey("EnnatysAika"); // poistetaan enn‰tysaika playerprefsist‰
        N‰yt‰Enn‰tysAika(); // kutsutaan metodia joka n‰ytt‰‰ enn‰tysajan
    }
}
