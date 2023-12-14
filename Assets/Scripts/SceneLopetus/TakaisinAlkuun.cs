using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinAlkuun : MonoBehaviour
{
    public Animator Haivytys; // haivytys animaattori
     
    public float Haivytysaika = 3f; // haivytys aika
    public void Takaisin() // kun painetaan nappia palataan alkunäyttöön
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti
        if (ajastin != null) // jos löytyy
        {
            ajastin.NollaaAjastin(); // nollataan ajastin
        }
        StartCoroutine(HaivytysKutsu(0)); // kutsutaan haivytyskutsu metodia
    }

    IEnumerator HaivytysKutsu(int levelIndex) // haivytyskutsu metodi
    {
        Haivytys.SetTrigger("Alku"); // käynnistetään haivytys animaatio

        yield return new WaitForSeconds(Haivytysaika); // odotetaan haivytysaika

        SceneManager.LoadScene(levelIndex);// Haetaan nykyisen kentän numero
    }
}
