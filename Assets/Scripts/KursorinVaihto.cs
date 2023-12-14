using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorinVaihto : MonoBehaviour
{
    //T‰ll‰ estet‰‰n ett‰ osoitin ei muutu objektien kohdalla kun ui paneeli on auki.

    //Array objekteille joiden p‰‰ll‰ osoitin muuttuu
    public GameObject[] objectsToCheck;

    //seuraavia metodeja kutsutaan muista luokista aina tarpeen mukaan

   //Metodi jolla laitetaan boxcollider p‰‰lle
    public void AktivoiScript()
        {
        //k‰yd‰‰n kaikki array objektit l‰pi
        foreach (var obj in objectsToCheck)
        {
            if (obj != null)
            {
                //haetaan boxcollider komponentti
                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    //laiotetaan se p‰‰lle
                    boxCollider.enabled = true;
                }
            }
        }
    }

    //Otetaan boxcollider pois p‰‰lt‰ niist‰ objekteista, jotka ovat arrayssa n‰in ollen myˆsk‰‰n osoitin ei muutu niiden yll‰
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
