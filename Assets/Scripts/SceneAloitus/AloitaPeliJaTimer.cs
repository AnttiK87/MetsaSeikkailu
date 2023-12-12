using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AloitaPeliJaTimer : MonoBehaviour
{
    public GameObject haivytysEkaan;
    public float Haivytysaika = 3f;
    public void StartGameAndTimer() // aloittaa pelin ja ajastimen
    {

        PelinKestoScripti timerScript = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti

        if (timerScript != null) // jos pelin kesto scripti löytyy
        {
            timerScript.KaynnistaAjastin(); // käynnistetään ajastin
        }
        else
        {
            print("PelinKestoScripti not found"); // jos pelin kesto scriptiä ei löydy annetaan error
        }

        StartCoroutine(HaivytysKutsu(1)); // loadataan scene 1 häivytykseen tarvittavalla viiveellä ja peli alkaa
    }

    //asetetaan häivytys aktiiviseksi ja annetaan viive seuraavan kentän lataamiselle
    IEnumerator HaivytysKutsu(int levelIndex)
    {
        haivytysEkaan.SetActive(true);

        yield return new WaitForSeconds(Haivytysaika);

        // Haetaan nykyisen kentän numero
        SceneManager.LoadScene(levelIndex);
    }
}
