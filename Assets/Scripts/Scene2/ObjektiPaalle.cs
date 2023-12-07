using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektiPaalle : MonoBehaviour
{
    //K�yt�ss� toisen kent�n animointien n�ytt��n
    //Aktivoidaan objekti viiveell�, ett� animaatio tapahtuu oikea aikaisesti
    //ChatGPT auttoi t�ss�

    public GameObject aktivoitavaObjekti;
    public float aktivoinninViive = 3f;

    private void Start()
    {
        //virheen hallintaa jos aktivoitavaa objektia ei ole m��ritetty
        if (aktivoitavaObjekti == null)
        {
            Debug.LogError("Aktivoitavaa objektia ei ole m��ritetty");
            enabled = false; 
        }

        // Kutsutaan viivytetty� aktivointia
        StartCoroutine(AktivoiObjektiViiveella());
    }

    //metodi objektin aktivoinnille viiveell�
    IEnumerator AktivoiObjektiViiveella()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(aktivoinninViive);

        // Activate the object after the delay
        aktivoitavaObjekti.SetActive(true);
    }
}