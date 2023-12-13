using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorinVaihto : MonoBehaviour
{

    public GameObject[] objectsToCheck;

    public void AktivoiScript()
        {
        foreach (var obj in objectsToCheck)
        {
            if (obj != null)
            {
                // Disable the BoxCollider component if it exists
                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = true;
                }
            }
        }
    }


    public void DeaktivoiScript()
    {

        foreach (var obj in objectsToCheck)
        {
            if (obj != null)
            {
                // Disable the BoxCollider component if it exists
                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
            }
        }


    }
}
