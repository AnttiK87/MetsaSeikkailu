using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinAlkuun : MonoBehaviour
{
    public void Takaisin() // kun painetaan nappia palataan alkunäyttöön
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti
        if (ajastin != null) // jos löytyy
        {
            ajastin.NollaaAjastin(); // nollataan ajastin
        }
        SceneManager.LoadScene(0);
    }
}
