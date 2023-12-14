using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorinVaihto : MonoBehaviour
{
    //Tämän luokan metodeja kutsutaan muualla aina tarpeen mukaan

    //Unityssa asetetaan objektit joiden päällä kursori muuttuu tähän arrayhin
    public GameObject[] objectsToCheck;

    //Boxcollider otetaan taas käyttöön tätä kutsuttaessa
    public void AktivoiScript()
        {
        foreach (var obj in objectsToCheck)
        {
            if (obj != null)
            {
                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = true;
                }
            }
        }
    }

    //Metodia kutsuttaessa arrayn objekteilta otetaan boxcollider komponentti pois käytöstä joten osoitin ei enää muutu sen yllä
    public void DeaktivoiScript()
    {

        foreach (var obj in objectsToCheck)
        {
            if (obj != null)
            {
                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
            }
        }


    }
}
