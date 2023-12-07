using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektiPois : MonoBehaviour
{
    //Sama kuin objekti p‰‰lle, mutt t‰ss‰ pois p‰‰lt‰ viiveell‰
    public GameObject aktivoitavaObjekti;
    public float aktivoinninViive = 3f;
    private void Start()
    {
        if (aktivoitavaObjekti == null)
        {
            Debug.LogError("Object to activate reference is not set!");
            enabled = false;
            return;
        }

        StartCoroutine(DeaktivoiObjektiViiveella());
    }

    IEnumerator DeaktivoiObjektiViiveella()
    {
        yield return new WaitForSeconds(aktivoinninViive);

        aktivoitavaObjekti.SetActive(false);
    }
}
