using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PelinKestoScripti : MonoBehaviour // scripti joka laskee pelin keston
{
    private float aloitusaika; // aloitusaika
    private float kulunutAika; // kulunut aika
    private bool ajastinKaynnissa = false; // onko ajastin k�ynniss�

    void Awake() // ei tuhoa t�t� scripti� kun vaihdetaan scene�
    {
        DontDestroyOnLoad(gameObject);
       // PlayerPrefs.DeleteKey("EnnatysAika"); // V�LIAIKAINEN 
    }

    public void KaynnistaAjastin() // aloittaa ajastimen
    {
        aloitusaika = Time.time; // aloitusaika on aika jolloin peli aloitetaan
        ajastinKaynnissa = true; // ajastin on k�ynniss�
        Debug.Log("Timer started at: " + Time.time); // debuggausta varten
    }

    public void PysaytaAjastin() // pys�ytt�� ajastimen
    {
        kulunutAika = Time.time - aloitusaika; // kulunut aika on aika jolloin peli lopetetaan - aloitusaika
        ajastinKaynnissa = false; // ajastin ei ole k�ynniss�
        Debug.Log("Timer stopped at: " + Time.time); // debuggausta varten
    }
    public void NollaaAjastin()
    {
        kulunutAika = 0; // kulunut aika on 0
        aloitusaika = Time.time; // aloitusaika on nykyinen aika
        ajastinKaynnissa = false; // ajastin ei ole k�ynniss�
        Debug.Log("Timer reset at: " + Time.time); // debuggausta varten
    }

    void Update() // p�ivitt�� kuluneen ajan
    {
        if (ajastinKaynnissa) // jos ajastin on k�ynniss�
        {
            kulunutAika = Time.time - aloitusaika; // kulunut aika on nykyinen aika - aloitusaika
        }
    }

    public int HaeKuluneetMinuutit() //palauttaa kuluneet minuutit
    {
        return (int)(kulunutAika / 60); // lasketaan kuluneet minuutit jakamalla kulunut sekunttiaika 60:ll�
    }

    public int HaeKuluneetSekunnit() // palauttaa kuluneet sekunnit
    {
        return (int)(kulunutAika % 60); // lasketaan kuluneet sekunnit jakamalla kulunut sekunttiaika 60:ll� ja ottamalla jakoj��nn�s
    }

    public void TarkistaJaTallennaEnnatysAika() // tarkistaa onko kulunut aika uusi enn�tysaika ja tallentaa sen
    {
        float vanhaEnnatys = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan vanha enn�tysaika
        if (kulunutAika < vanhaEnnatys) // jos kulunut aika on pienempi kuin vanha enn�tysaika
        {
            PlayerPrefs.SetFloat("EnnatysAika", kulunutAika); // tallennetaan uusi enn�tysaika
            PlayerPrefs.Save(); // varmistetaan, ett� tieto tallennetaan v�litt�m�sti
        }
    }

    public void VaaraVastausNappiaPainaessa(Button painettuNappi) // jos painetaan v��r�� vastausnappia, lis�t��n aikaa 5 sek timeriin
    {
        if (painettuNappi.CompareTag("VaaraVastaus"))
        {
            LisaaAikaa();
        }
    }

    public void LisaaAikaa() // lis�� aikaa
    {
        if (ajastinKaynnissa)
        {
            aloitusaika -= 5; // v�hennet��n 5 sekunttia aloitusajasta
            Debug.Log("5 sekunttia lis�tty timeriin"); // debuggausta varten
        }
    }


}

