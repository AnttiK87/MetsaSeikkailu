using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaJaSulje : MonoBehaviour
{

    public GameObject VinkkiCanvas;
    public AudioSource vinkkiAani;

    public void Start()
    {
        if (VinkkiCanvas != null)
        {
            VinkkiCanvas.SetActive(false);
        }
    }
    

    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateVinkki1();
        vinkkiAani.Play();
    }

    void ActivateVinkki1()
    {
        if (VinkkiCanvas != null)
        {
            VinkkiCanvas.SetActive(true);
        }
    }

    public void suljeVinkki1()
    {
        VinkkiCanvas.SetActive(false);
    }
}
