using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement; // tarvitaan scenejen vaihtamiseen


public class PelinKestoScripti : MonoBehaviour // scripti joka laskee pelin keston
{
    private float aloitusaika; // aloitusaika
    private float kulunutAika; // kulunut aika
    private bool ajastinKaynnissa = false; // onko ajastin k‰ynniss‰
    private float vaaratVastaukset = 0; // v‰‰r‰t vastaukset laskuri
    private float lopullinenAika = float.MaxValue; // lopullinen aika on max float, jotta se on varmasti suurempi kuin mik‰‰n mahdollinen aika

    void Awake() // ei tuhoa t‰t‰ scripti‰ kun vaihdetaan scene‰
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // lis‰t‰‰n listeneri, joka kutsuu OnSceneLoaded funktiota kun scene vaihtuu
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) // kun scene vaihtuu
    {
        Debug.Log("Scene loaded"); // debuggausta varten
    }


    public void LisaaAikaa() // lis‰‰ aikaa
    {
        if (ajastinKaynnissa)
        {
            vaaratVastaukset += 5; // lis‰t‰‰n 5 sekunttia v‰‰r‰st‰ vastauksesta
        }
    }

    IEnumerator TimerDebugCoroutine()
    {
        while (ajastinKaynnissa)
        {
            Debug.Log("Timerin aika on: " + Time.time + " Vaarat Vastaukset on: " + vaaratVastaukset);
            yield return new WaitForSeconds(1f); // Odotetaan 1 sekunti ennen seuraavaa p‰ivityst‰
        }
    }

    //timeriin liittyv‰t funktiot
    public void KaynnistaAjastin() // aloittaa ajastimen
    {
        aloitusaika = Time.time; // aloitusaika on aika jolloin peli aloitetaan
        ajastinKaynnissa = true; // ajastin on k‰ynniss‰
        Debug.Log("Timer started at: " + Time.time); // debuggausta varten

        StartCoroutine(TimerDebugCoroutine()); // K‰ynnist‰ Coroutine
    }

    public void PysaytaAjastin() // pys‰ytt‰‰ ajastimen
    {
        kulunutAika = Time.time - aloitusaika; // kulunut aika on aika jolloin peli lopetetaan - aloitusaika
        lopullinenAika = kulunutAika + vaaratVastaukset; // lopullinen aika on kulunut aika + v‰‰r‰t vastaukset
        ajastinKaynnissa = false; // ajastin ei ole k‰ynniss‰
        Debug.Log("Timer stopped at: " + Time.time); // debuggausta varten
        Debug.Log("Lopullinen aika:" + lopullinenAika); // debuggausta varten

        StopCoroutine(TimerDebugCoroutine()); // Lopeta Coroutine
    }
    public void NollaaAjastin()
    {
        kulunutAika = 0; // kulunut aika on 0
        aloitusaika = Time.time; // aloitusaika on nykyinen aika
        ajastinKaynnissa = false; // ajastin ei ole k‰ynniss‰
        Debug.Log("Timer reset at: " + Time.time); // debuggausta varten
    }

    public int HaeKuluneetMinuutit() //palauttaa kuluneet minuutit
    {
        return (int)(lopullinenAika / 60); // lasketaan kuluneet minuutit jakamalla kulunut sekunttiaika 60:ll‰
    }

    public int HaeKuluneetSekunnit() // palauttaa kuluneet sekunnit
    {
        return (int)(lopullinenAika % 60); // lasketaan kuluneet sekunnit jakamalla kulunut sekunttiaika 60:ll‰ ja ottamalla jakoj‰‰nnˆs
    }

    public void TarkistaJaTallennaEnnatysAika() // tarkistaa onko kulunut aika uusi enn‰tysaika ja tallentaa sen
    {
        float vanhaEnnatys = PlayerPrefs.GetFloat("EnnatysAika", float.MaxValue); // haetaan vanha enn‰tysaika
        if (lopullinenAika < vanhaEnnatys) // jos kulunut aika on pienempi kuin vanha enn‰tysaika
        {
            PlayerPrefs.SetFloat("EnnatysAika", lopullinenAika); // tallennetaan uusi enn‰tysaika
            PlayerPrefs.Save(); // varmistetaan, ett‰ tieto tallennetaan v‰littˆm‰sti
        }
    }

}

