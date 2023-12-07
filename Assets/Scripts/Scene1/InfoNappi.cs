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
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(infoNappi);
        DontDestroyOnLoad(infoPanel);
        DontDestroyOnLoad(infoNappiCanvas);

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // kun scene vaihtuu
    {
        if (scene.buildIndex == 7) // tarkistetaan onko loaded scene 7 jolloin tuhotaan info objektit ja t�m� scripti
        {
            Destroy(infoNappi);
            Destroy(infoPanel);
            Destroy(infoNappiCanvas);
            Destroy(gameObject); // viimeisen� tuhotaan t�m� scripti

            SceneManager.sceneLoaded -= OnSceneLoaded; // poistetaan eventti
        }
    }

    void OnDestroy() // kun t�m� scripti tuhotaan niin poistetaan my�s eventti
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    //kun painetaan info nappia niin info paneli tulee n�kyviin ja kun painetaan uudestaan se menee pois n�kyvist�
    public void InfoNappiPainettu()
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
