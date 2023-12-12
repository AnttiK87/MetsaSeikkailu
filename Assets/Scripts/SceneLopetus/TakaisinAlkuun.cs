using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinAlkuun : MonoBehaviour
{
    public Animator Haivytys;

    public float Haivytysaika = 3f;
    public void Takaisin() // kun painetaan nappia palataan alkunäyttöön
    {
        PelinKestoScripti ajastin = FindObjectOfType<PelinKestoScripti>(); // etsitään pelin kesto scripti
        if (ajastin != null) // jos löytyy
        {
            ajastin.NollaaAjastin(); // nollataan ajastin
        }
        StartCoroutine(HaivytysKutsu(0));
    }

    IEnumerator HaivytysKutsu(int levelIndex)
    {
        Haivytys.SetTrigger("Alku");

        yield return new WaitForSeconds(Haivytysaika);

        // Haetaan nykyisen kentän numero
        SceneManager.LoadScene(levelIndex);
    }
}
