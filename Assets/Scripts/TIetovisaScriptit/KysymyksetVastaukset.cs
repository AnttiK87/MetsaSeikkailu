using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class KysymyksetVastaukset 
{
    // Tekstimuuttuja, joka sis‰lt‰‰ itse kysymyksen
    public string Kysymys;
    // Taulukko, joka sis‰lt‰‰ kysymykseen liittyv‰t vastaukset
    public string[] Vastaukset;
    // Kokonaislukumuuttuja, joka kertoo, mik‰ vastaus on oikea
    public int OikeaVastaus;
}
