using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursori : MonoBehaviour
{
    //T‰ll‰ saatu kursori muuttumaan niiden objektien kohdalla 
    //joihin scripti on liitetty. 

    //muuttujat
    public Texture2D cursorTextureMuut;
    public CursorMode cursorModeMuut = CursorMode.Auto;
    public Vector2 hotSpotMuut = Vector2.zero;

    //Kun hiiri tulee objektin (boxcollider) ylle aktivoidaan cursortextureen m‰‰ritetty eri osoitin.
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTextureMuut, hotSpotMuut, cursorModeMuut);
    }

    //kun hiiri poistuu muutetaan texture null:ksi eli oletus arvoon.
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorModeMuut);
    }
}
