using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LopetaPelinAjastin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LopetaPeliJaTimer() // kun painetaan nappia joka lopettaa pelin
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsit��n pelin kesto scripti
        if (ajastin != null) // jos l�ytyy
        {
            ajastin.PysaytaAjastin(); // pys�ytet��n ajastin
        }
       // lataa scene 7
       UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }
}
