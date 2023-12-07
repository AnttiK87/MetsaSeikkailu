using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektiPaalle : MonoBehaviour
{
    //Käytössä toisen kentän animointien näyttöön
    //Aktivoidaan objekti viiveellä, että animaatio tapahtuu oikea aikaisesti
    //ChatGPT auttoi tässä

    public GameObject aktivoitavaObjekti;
    public float aktivoinninViive = 3f;

    private void Start()
    {
        //virheen hallintaa jos aktivoitavaa objektia ei ole määritetty
        if (aktivoitavaObjekti == null)
        {
            Debug.LogError("Aktivoitavaa objektia ei ole määritetty");
            enabled = false; 
        }

        // Kutsutaan viivytettyä aktivointia
        StartCoroutine(AktivoiObjektiViiveella());
    }

    //metodi objektin aktivoinnille viiveellä
    IEnumerator AktivoiObjektiViiveella()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(aktivoinninViive);

        // Activate the object after the delay
        aktivoitavaObjekti.SetActive(true);
    }
}