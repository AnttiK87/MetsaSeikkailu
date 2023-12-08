using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeuraavaScene : MonoBehaviour
{
    public GameObject objektiPois;
    public GameObject objektiPaalle;
    //Objekti johon scripti on liitetty toimimaan nappina
    private void OnMouseUpAsButton()
    {
        objektiPois.SetActive(false);
        objektiPaalle.SetActive(true);

        if (objektiPois == null && objektiPaalle == null )
        {
            LataaSeuraavaScene();
        }
    }

    //Ladataan seuraava kentt‰
    public void LataaSeuraavaScene()
    {
        // Haetaan nykyisen kent‰n numero
        int nykyisenScenenIndeksi = SceneManager.GetActiveScene().buildIndex;

        // Nis‰t‰‰n nykyiseen yksi eli ladataan seuraava kentt‰
        SceneManager.LoadScene(nykyisenScenenIndeksi + 1);
    }
}
