using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AloitaPeliJaTimer : MonoBehaviour
{
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
    }
}
