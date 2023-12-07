using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoNappi : MonoBehaviour
{
    public GameObject infoNappi; // info nappi
    public GameObject infoPanel; // info paneli
    public GameObject infoNappiCanvas; // info nappi canvas

    void Awake() // ei tuhoa tätä scriptiä tai info objekteja kun vaihdetaan sceneä
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(infoNappiCanvas);

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // kun scene vaihtuu
    {
        if (scene.buildIndex == 7) // tarkistetaan onko loaded scene 7 jolloin tuhotaan info objektit ja tämä scripti
        {

            Destroy(infoNappiCanvas);
            Destroy(gameObject); // viimeisenä tuhotaan tämä scripti

            SceneManager.sceneLoaded -= OnSceneLoaded; // poistetaan eventti
        }
    }

    void OnDestroy() // kun tämä scripti tuhotaan niin poistetaan myös eventti
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    //kun painetaan info nappia niin info paneli tulee näkyviin ja kun painetaan uudestaan se menee pois näkyvistä
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
