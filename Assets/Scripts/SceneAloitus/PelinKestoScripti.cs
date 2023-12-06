using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PelinKestoScripti : MonoBehaviour // scripti joka laskee pelin keston
{
    private float aloitusaika; // aloitusaika
    private float kulunutAika; // kulunut aika
    private bool ajastinKaynnissa = false; // onko ajastin käynnissä

    void Awake() // ei tuhoa tätä scriptiä kun vaihdetaan sceneä
    {
        DontDestroyOnLoad(gameObject);
       // PlayerPrefs.DeleteKey("EnnatysAika"); // VÄLIAIKAINEN 
    }

    public void KaynnistaAjastin() // aloittaa ajastimen
    {
        aloitusaika = Time.time; // aloitusaika on aika jolloin peli aloitetaan
        ajastinKaynnissa = true; // ajastin on käynnissä
        Debug.Log("Timer started at: " + Time.time); // debuggausta varten
    }

    public void PysaytaAjastin() // pysäyttää ajastimen
    {
        kulunutAika = Time.time - aloitusaika; // kulunut aika on aika jolloin peli lopetetaan - aloitusaika
        ajastinKaynnissa = false; // ajastin ei ole käynnissä
        Debug.Log("Timer stopped at: " + Time.time); // debuggausta varten
    }

    void Update() // päivittää kuluneen ajan
    {
        if (ajastinKaynnissa) // jos ajastin on käynnissä
        {
            kulunutAika = Time.time - aloitusaika; // kulunut aika on nykyinen aika - aloitusaika
        }
    }

    public int HaeKuluneetMinuutit() //palauttaa kuluneet minuutit
    {
        return (int)(kulunutAika / 60); // lasketaan kuluneet minuutit jakamalla kulunut sekunttiaika 60:llä
    }

    public int HaeKuluneetSekunnit() // palauttaa kuluneet sekunnit
    {
        return (int)(kulunutAika % 60); // lasketaan kuluneet sekunnit jakamalla kulunut sekunttiaika 60:llä ja ottamalla jakojäännös
    }

    public void TarkistaJaTallennaEnnatysAika() // tarkistaa onko kulunut aika uusi ennätysaika ja tallentaa sen
    {
        float vanhaEnnatys = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan vanha ennätysaika
        if (kulunutAika < vanhaEnnatys) // jos kulunut aika on pienempi kuin vanha ennätysaika
        {
            PlayerPrefs.SetFloat("EnnatysAika", kulunutAika); // tallennetaan uusi ennätysaika
            PlayerPrefs.Save(); // varmistetaan, että tieto tallennetaan välittömästi
        }
    }

}

