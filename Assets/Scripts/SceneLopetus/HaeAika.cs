using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HaeAika : MonoBehaviour
{
    public TextMeshProUGUI aikaTeksti;  // teksti johon tulee aika
    public TextMeshProUGUI ennätysAikaTeksti;  // teksti johon tulee ennätysaika

    void Start() 
    {
        if (aikaTeksti == null) // jos aikaTeksti ei ole asetettu Inspectorissa
        {
            print("aikaTeksti not assigned in the Inspector"); // annetaan error
            return;
        }

        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti ja luodaan siitä olio

        if (ajastin != null) // jos pelin kesto scripti löytyy
        {
            int minuutit = ajastin.HaeKuluneetMinuutit(); // haetaan kuluneet minuutit
            int sekunnit = ajastin.HaeKuluneetSekunnit(); // haetaan kuluneet sekunnit
            aikaTeksti.text = "Seikkailusi kesto: " + minuutit + " min " + sekunnit + " s"; // asetetaan tekstiin kulunut aika

            PäivitäEnnätysAika(minuutit, sekunnit);// kutsutaan ennätysajan päivitys metodia
        }
        else
        {
            print("PelinKestoScripti not found"); // jos pelin kesto scriptiä ei löydy annetaan error
        }
    }

    void PäivitäEnnätysAika(int minuutit, int sekunnit) // metodi päivittää ennätysajan
    {
        float nykyinenAika = minuutit * 60 + sekunnit; // lasketaan nykyinen aika taas sekunneiksi
        float ennatysAika = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan vanha ennätysaika

        if (nykyinenAika < ennatysAika) // jos nykyinen aika on pienempi kuin vanha ennätysaika
        {
            PlayerPrefs.SetFloat("EnnatysAika", nykyinenAika); // tallennetaan uusi ennätysaika
            PlayerPrefs.Save(); // tallennetaan välittömästi
        }

        NäytäEnnätysAika(); // kutsutaan metodia joka näyttää ennätysajan
    }

    void NäytäEnnätysAika() // metodi näyttää ennätysajan
    {
        if (ennätysAikaTeksti != null) // jos ennatysAikaTeksti on asetettu
        {
            float ennatysAika = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan ennätysaika
            if (ennatysAika != float.MaxValue) // jos ennätysaika ei ole float.MaxValue eli se on asetettu
            {
                int ennatysMinuutit = (int)(ennatysAika / 60); // lasketaan minuutit jakamalla ennätysaika 60:llä
                int ennatysSekunnit = (int)(ennatysAika % 60); // lasketaan sekunnit jakamalla ennätysaika 60:llä ja ottamalla jakojäännös
                ennätysAikaTeksti.text = "Nopein aika: " + ennatysMinuutit + " min " + ennatysSekunnit + " s"; // asetetaan tekstiin ennätysaika
            }
            else // jos ennätysaika on float.MaxValue eli sitä ei ole asetettu
            {
                ennätysAikaTeksti.text = "Nopein aika: - "; // asetetaan tekstiin -
            }
        }
    }
}
