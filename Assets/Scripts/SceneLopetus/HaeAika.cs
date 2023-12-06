using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaeAika : MonoBehaviour
{
    public Text aikaTeksti;

    void Start()
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); //etsit‰‰n pelinkestoscripti ja tallennetaan se muuttujaan
        if (ajastin != null)
        {
            aikaTeksti.text = "Seikkailusi kesto:  " + ajastin.HaeKulunutAika() + "";
        }
    }
}

