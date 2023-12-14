using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Kyselija : MonoBehaviour
{ 
    //Objekti johon t�m� on liitetty toimii nappina ja aktivoi kyselij�ksi m��ritetyn objektin
    public GameObject kyselija;

    //Liitetty objekti toimimaan nappina
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    // Kyselij�n aktivointi metodi. Peliss� kameran k��nt� objektia kohti ja animaatioiden aloitus hy�dynt�� sit�, ett� objekti tulee aktiiviseksi.
    //Siksi t�m�n tyylist� ratkaisua k�ytetty paljon. 
    void ActivateObject()
    {
        if (kyselija != null)
        {

            kyselija.SetActive(true);
        }
    }
}
