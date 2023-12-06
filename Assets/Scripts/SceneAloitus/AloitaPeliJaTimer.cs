using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AloitaPeliJaTimer : MonoBehaviour
{
    public void StartGameAndTimer() // aloittaa pelin ja ajastimen
    {

        PelinKestoScripti timerScript = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti

        if (timerScript != null) // jos pelin kesto scripti löytyy
        {
            timerScript.KaynnistaAjastin();
        }
        else
        {
            print("PelinKestoScripti not found"); // jos pelin kesto scriptiä ei löydy annetaan error
        }

        SceneManager.LoadScene(1); // loadataan scene 1 eli peli alkaa
    }
}
