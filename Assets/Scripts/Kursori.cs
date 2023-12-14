using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursori : MonoBehaviour
{
    //Osoitin muuttumaan erin‰kˆiseksi kun hiiri vied‰‰n objektin (boxcolliderin p‰‰lle) 

    //Muuttujat
    public Texture2D cursorTextureMuut;
    public CursorMode cursorModeMuut = CursorMode.Auto;
    public Vector2 hotSpotMuut = Vector2.zero;

    //Muutetaan kursori muuttujaan asetetun tekstuurin mukaisesti
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTextureMuut, hotSpotMuut, cursorModeMuut);
    }

    //Muutetaan takaisin oletukseksi (null) kun hiiri vied‰‰n pois
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorModeMuut);
    }
}
