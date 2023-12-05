using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TietovisaAvaus: MonoBehaviour 
{
    public KysymysManageri kysymysManageri;

    private void OnMouseDown()
    {
        if (kysymysManageri != null)
        {
            kysymysManageri.AktivoiTietoVisaCanvas();
        }
    }
}
