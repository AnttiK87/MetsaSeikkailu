using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoNappi : MonoBehaviour
{
    public GameObject infoNappi; // info nappi
    public GameObject infoPanel; // info paneli
    public GameObject infoNappiCanvas; // info nappi canvas

    void Awake() // ei tuhoa t�t� scripti� tai info objekteja kun vaihdetaan scene�
    {
        DontDestroyOnLoad(gameObject); // ei tuhoa t�t� scripti� kun vaihdetaan scene�
        DontDestroyOnLoad(infoNappiCanvas); // ei tuhoa info nappi canvasia kun vaihdetaan scene�

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // kun scene vaihtuu
    {
        if (scene.buildIndex == 7) // tarkistetaan onko loaded scene 7 jolloin tuhotaan info objektit ja t�m� scripti
        {

            Destroy(infoNappiCanvas);
            Destroy(gameObject); // viimeisen� tuhotaan t�m� scripti

            SceneManager.sceneLoaded -= OnSceneLoaded; // poistetaan eventti
        }
    }

    void OnDestroy() // kun t�m� scripti tuhotaan niin poistetaan my�s eventti
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    public void InfoNappiPainettu()//kun painetaan info nappia niin info paneeli tulee n�kyviin ja kun painetaan uudestaan se menee pois n�kyvist�
    {
        if (!infoPanel.activeSelf && infoPanel != null) // jos info panel ei ole aktiivinen ja se ei ole null
        {
            infoPanel.SetActive(true); // laitetaan info panel aktiiviseksi
        }
        else // muuten
        {
            infoPanel.SetActive(false); // laitetaan info panel ei aktiiviseksi
        }
    }
}
