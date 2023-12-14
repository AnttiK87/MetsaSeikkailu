using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorinVaihto : MonoBehaviour
{
    //T�m�n luokan metodeja kutsutaan muualla aina tarpeen mukaan

    //Unityssa asetetaan objektit joiden p��ll� kursori muuttuu t�h�n arrayhin
    public GameObject[] objectsToCheck;

    //Boxcollider otetaan taas k�ytt��n t�t� kutsuttaessa
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

    //Metodia kutsuttaessa arrayn objekteilta otetaan boxcollider komponentti pois k�yt�st� joten osoitin ei en�� muutu sen yll�
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
