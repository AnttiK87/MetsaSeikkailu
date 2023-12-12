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

        PelinKestoScripti timerScript = FindObjectOfType<PelinKestoScripti>(); // etsit��n pelin kesto scripti

        if (timerScript != null) // jos pelin kesto scripti l�ytyy
        {
            timerScript.KaynnistaAjastin(); // k�ynnistet��n ajastin
        }
        else
        {
            print("PelinKestoScripti not found"); // jos pelin kesto scripti� ei l�ydy annetaan error
        }

        StartCoroutine(HaivytysKutsu(1)); // loadataan scene 1 h�ivytykseen tarvittavalla viiveell� ja peli alkaa
    }

    //asetetaan h�ivytys aktiiviseksi ja annetaan viive seuraavan kent�n lataamiselle
    IEnumerator HaivytysKutsu(int levelIndex)
    {
        haivytysEkaan.SetActive(true);

        yield return new WaitForSeconds(Haivytysaika);

        // Haetaan nykyisen kent�n numero
        SceneManager.LoadScene(levelIndex);
    }
}
