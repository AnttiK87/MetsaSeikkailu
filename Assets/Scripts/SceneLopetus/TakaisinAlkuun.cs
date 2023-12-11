using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinAlkuun : MonoBehaviour
{
    public void Takaisin() // kun painetaan nappia palataan alkun�ytt��n
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsit��n pelin kesto scripti
        if (ajastin != null) // jos l�ytyy
        {
            ajastin.NollaaAjastin(); // nollataan ajastin
        }
        SceneManager.LoadScene(0);
    }
}
