using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorinVaihto : MonoBehaviour
{
    public Texture2D cursorTextureMuut;
    public CursorMode cursorModeMuut = CursorMode.Auto;
    public Vector2 hotSpotMuut = Vector2.zero;

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTextureMuut, hotSpotMuut, cursorModeMuut);
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorModeMuut);
    }
}
