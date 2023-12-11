using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeuraavaScene : MonoBehaviour
{
    public GameObject objektiPois;
    public GameObject objektiPaalle;
    public Animator Haivytys;

    public float Haivytysaika = 3f;
    //Objekti johon scripti on liitetty toimimaan nappina
    private void OnMouseUpAsButton()
    {
        if (objektiPois != null && objektiPaalle != null)
        {
            objektiPois.SetActive(false);
            objektiPaalle.SetActive(true);
        }
        else
        {
            LataaSeuraavaScene();
        }
    }

    //Ladataan seuraava kentt‰
    public void LataaSeuraavaScene()
    {
        // Lis‰t‰‰n nykyiseen yksi eli ladataan seuraava kentt‰
        StartCoroutine(HaivytysKutsu(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator HaivytysKutsu(int levelIndex)
    {
        Haivytys.SetTrigger("Alku");

        yield return new WaitForSeconds(Haivytysaika);

        // Haetaan nykyisen kent‰n numero
        SceneManager.LoadScene(levelIndex);
    }
}
