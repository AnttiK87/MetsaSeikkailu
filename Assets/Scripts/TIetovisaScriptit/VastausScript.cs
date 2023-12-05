using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class VastausScript : MonoBehaviour
{
    public bool onOikein = false;
    public KysymysManageri kysymysManageri;
    

    private void Start()
    {
        // Liitet‰‰n Vastaus-metodi napin OnClick-tapahtumaan
        GetComponent<Button>().onClick.AddListener(Vastaus);
    }

    public void Vastaus()
    {
        if (onOikein)
        {
            Debug.Log("Oikea vastaus");
            kysymysManageri.oikein();
        }
        else
        {
            Debug.Log("V‰‰r‰ vastaus");          
            vaarin();
        }
        

    }
    public void vaarin()
    {
        Debug.Log("V‰‰r‰ vastaus k‰sitelty");
        // T‰h‰n voit lis‰t‰ tarvittavat toiminnot v‰‰r‰lle vastaukselle
    }
}
