using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    // kun painetaan nappia niin lopetetaan peli ja siirryt‰‰n sceneen 8
    public void LopetaPeli()
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsit‰‰n pelin kesto scripti
        if (ajastin != null) // jos lˆytyy
        {
            ajastin.PysaytaAjastin(); // pys‰ytet‰‰n ajastin
            ajastin.NollaaAjastin(); // nollataan ajastin
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(8); // lataa scene 8

    }
}
