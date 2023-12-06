using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PelinKestoScripti : MonoBehaviour
{
    private float aloitusaika;
    private float kulunutAika;
    private bool ajastinKaynnissa = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void KaynnistaAjastin()
    {
        aloitusaika = Time.time;
        ajastinKaynnissa = true;
    }

    public void PysaytaAjastin()
    {
        kulunutAika = Time.time - aloitusaika;
        ajastinKaynnissa = false;
    }

    void Update()
    {
        if (ajastinKaynnissa)
        {
            kulunutAika = Time.time - aloitusaika;
        }
    }

    public float HaeKulunutAika()
    {
        return kulunutAika;
    }
}

