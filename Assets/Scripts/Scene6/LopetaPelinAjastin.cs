using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LopetaPelinAjastin : MonoBehaviour
{
    public void LopetaPeliJaTimer() // Kutsutaan pelin lopettavan animaation lopuksi
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti
        if (ajastin != null) // jos löytyy
        {
            ajastin.PysaytaAjastin(); // pysäytetään ajastin
        }
    }
}
