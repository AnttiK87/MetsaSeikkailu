using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HaeAika : MonoBehaviour // hakee pelin keston ja n�ytt�� sen tekstin�
{
    public TextMeshProUGUI aikaTeksti;  // teksti johon tulee aika

    void Start() // kutsutaan kun scene alkaa
    {
        if (aikaTeksti == null) // jos aikaTeksti� ei ole asetettu inspectorissa
        {
            print("aikaTeksti not assigned in the Inspector"); // annetaan error
            return;
        }

        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsit��n pelin kesto scripti

        if (ajastin != null)
        {
            aikaTeksti.text = "Seikkailusi kesto: " + ajastin.HaeKulunutAika(); // aikaTekstiin tulee seikkailun kesto
        }
        else
        {
            print("PelinKestoScripti not found"); // jos pelin kesto scripti� ei l�ydy annetaan error
        }
    }
}


