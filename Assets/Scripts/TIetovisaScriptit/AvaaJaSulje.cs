using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaJaSulje : MonoBehaviour
{

    public GameObject VinkkiCanvas;
    public AudioSource vinkkiAani;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private string klikattu;


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
        // M‰‰ritet‰‰n klikattiinko objektia ja mik‰ se oli
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Jos osui objektiin
        if (Physics.Raycast(ray, out hit))
        {
            // Haetaan objektille oleva tagi 
            if (hit.collider.gameObject.tag != null)
            {
                //tallennetaan tagi muuttujaan
                klikattu = hit.collider.gameObject.tag;
            }
            if (klikattu.Equals("Vinkkaaja"))
            {
                //Debug.Log("nappia painettu");
                ActivateVinkki1();
            }
        }
    }

    void ActivateVinkki1()
    {

            if (VinkkiCanvas != null && !GameObject.FindWithTag("Vinkki"))
            {
                VinkkiCanvas.SetActive(true);
                vinkkiAani.Play();
            }
 
   
    }

    public void suljeVinkki1()
    {
        VinkkiCanvas.SetActive(false);
    }
}
