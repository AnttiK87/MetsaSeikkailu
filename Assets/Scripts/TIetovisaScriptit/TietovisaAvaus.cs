using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TietovisaAvaus: MonoBehaviour 
{
    // Viittaus KysymysManageriin, jotta voimme kutsua sen metodeita
    public KysymysManageri kysymysManageri;

    // Kutsutaan, kun hiiren nappi painetaan alueen p‰‰ll‰
    private void OnMouseDown()
    {
        // Tarkistetaan, ett‰ kysymysManageri on m‰‰ritetty
        if (kysymysManageri != null)
        {
            // Kutsutaan KysymysManagerin AktivoiTietoVisaCanvas-metodia
            kysymysManageri.AktivoiTietoVisaCanvas();
        }
    }
}
