using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaJaSulje : MonoBehaviour
{

    public GameObject VinkkiCanvas;
    public GameObject panelVinkki1;
    public GameObject panelVinkki2;
    public GameObject panelVinkki3;
    public GameObject panelVinkki4;
    public AudioSource vinkkiAani;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    public void Start()
    {
        if (VinkkiCanvas != null)
        {
            VinkkiCanvas.SetActive(false);
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateVinkki1();
        vinkkiAani.Play();
    }

    void ActivateVinkki1()
    {
        if (panelVinkki4 == null)
        {
            if (VinkkiCanvas != null && !panelVinkki1.activeSelf && !panelVinkki2.activeSelf && !panelVinkki3.activeSelf)
            {
                VinkkiCanvas.SetActive(true);
            }
        }
        else
        {
            if (VinkkiCanvas != null && !panelVinkki1.activeSelf && !panelVinkki2.activeSelf && !panelVinkki3.activeSelf && !panelVinkki4.activeSelf)
            {
                VinkkiCanvas.SetActive(true);
            }
        }
   
    }

    public void suljeVinkki1()
    {
        VinkkiCanvas.SetActive(false);
    }
}
