using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinkki : MonoBehaviour
{
    public GameObject panelVinkki1;
    public GameObject panelVinkki2;
    public GameObject panelVinkki3;
    public GameObject panelVinkki4;
    public GameObject Kysymykset;
    private string klikattu;
    private bool isEnabled = false;

    public static Vinkki VinkkiInstanssi;
    private void Awake()
    {
        if (VinkkiInstanssi == null)
        {
            VinkkiInstanssi = this;
        }
    }

    private void Update()
    {
        // Check for mouse click

            if (Input.GetMouseButtonDown(0))
            {
                // Raycast to determine what object was clicked
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the clicked object has a name
                    if (hit.collider.gameObject.tag != null)
                    {
                        // Get the name of the clicked object
                        klikattu = hit.collider.gameObject.tag;

                        // Now you can use the 'clickedObjectName' variable as needed
                        Debug.Log("Clicked object name: " + klikattu);
                        if (isEnabled)
                        {
                            ActivateVinkki(klikattu);
                        }
                    }
                }
            }
       
    }


    void ActivateVinkki(string klikattuObjekti)
    {
        if (!Kysymykset.activeSelf && Kysymykset != null)
        {
             if (klikattuObjekti.Equals("Vinkki1"))
            {
                panelVinkki1.SetActive(true);
            }
            else if (klikattuObjekti.Equals("Vinkki2"))
            {
                panelVinkki2.SetActive(true);
            }
            else if (klikattuObjekti.Equals("Vinkki3"))
            {
                panelVinkki3.SetActive(true);
            }
            else if (klikattuObjekti.Equals("Vinkki4"))
            {
                panelVinkki4.SetActive(true);
            }
        }
    }

    public void suljeVinkki1()
    {
        panelVinkki1.SetActive(false);
        panelVinkki2.SetActive(false);
        panelVinkki3.SetActive(false);
        panelVinkki4.SetActive(false);
    }

    public void AktivoiScript()
    {
        
        isEnabled = true;

        
    }

    public void DeaktivoiScript()
    {
        
        isEnabled = false;

        
    }
}
