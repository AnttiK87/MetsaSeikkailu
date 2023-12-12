using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LopetaPelinAjastin : MonoBehaviour
{
    public void LopetaPeliJaTimer() // Kutsutaan pelin lopettavan animaation lopuksi
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsit��n pelin kesto scripti
        if (ajastin != null) // jos l�ytyy
        {
            ajastin.PysaytaAjastin(); // pys�ytet��n ajastin
        }
    }
}
