using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Kyselija : MonoBehaviour
{ 
    //Objekti johon tämä on liitetty toimii nappina ja aktivoi kyselijäksi määritetyn objektin
    public GameObject kyselija;

    //Liitetty objekti toimimaan nappina
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    // Kyselijän aktivointi metodi. Pelissä kameran kääntö objektia kohti ja animaatioiden aloitus hyödyntää sitä, että objekti tulee aktiiviseksi.
    //Siksi tämän tyylistä ratkaisua käytetty paljon. 
    void ActivateObject()
    {
        if (kyselija != null)
        {

            kyselija.SetActive(true);
        }
    }
}
