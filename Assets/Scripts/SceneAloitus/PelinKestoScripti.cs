using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PelinKestoScripti : MonoBehaviour // scripti joka laskee pelin keston
{
    private float aloitusaika; // aloitusaika
    private float kulunutAika; // kulunut aika
    private bool ajastinKaynnissa = false; // onko ajastin k‰ynniss‰

    void Awake() // ei tuhoa t‰t‰ scripti‰ kun vaihdetaan scene‰
    {
        DontDestroyOnLoad(gameObject); 
    }

    public void KaynnistaAjastin() // aloittaa ajastimen
    {
        aloitusaika = Time.time; // aloitusaika on aika jolloin peli aloitetaan
        ajastinKaynnissa = true; // ajastin on k‰ynniss‰
        Debug.Log("Timer started at: " + Time.time); // debuggausta varten
    }

    public void PysaytaAjastin() // pys‰ytt‰‰ ajastimen
    {
        kulunutAika = Time.time - aloitusaika; // kulunut aika on aika jolloin peli lopetetaan - aloitusaika
        ajastinKaynnissa = false; // ajastin ei ole k‰ynniss‰
        Debug.Log("Timer stopped at: " + Time.time); // debuggausta varten
    }

    void Update() // p‰ivitt‰‰ kuluneen ajan
    {
        if (ajastinKaynnissa) // jos ajastin on k‰ynniss‰
        {
            kulunutAika = Time.time - aloitusaika; // kulunut aika on nykyinen aika - aloitusaika
        }
    }

    public string HaeKulunutAika() // palauttaa kuluneen ajan
    {
            int kokonaisaikaSekunteina = (int)(kulunutAika); // kokonaisaika sekunteina on kulunut aika
            int minuutit = kokonaisaikaSekunteina / 60; // minuutit on kokonaisaika sekunteina jaettuna 60
            int sekunnit = kokonaisaikaSekunteina % 60; // sekunnit on jakoj‰‰nnˆs 60 ja kokonaisaika sekunteina
            return string.Format("{0:00}:{1:00}", minuutit, sekunnit); // palauttaa kuluneen ajan muodossa mm:ss
    }
}

