using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektiPois : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationDelay = 3f; // Adjust the delay in seconds

    private void Start()
    {
        if (objectToActivate == null)
        {
            Debug.LogError("Object to activate reference is not set!");
            enabled = false; // Disable the script if the object to activate reference is not set
            return;
        }

        // Start the coroutine for delayed activation
        StartCoroutine(ActivateObjectWithDelay());
    }

    IEnumerator ActivateObjectWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(activationDelay);

        // Activate the object after the delay
        objectToActivate.SetActive(false);
    }
}
