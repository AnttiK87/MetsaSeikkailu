using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoNappi : MonoBehaviour
{
    public GameObject infoNappi; // info nappi
    public GameObject infoPanel; // info paneli
    public GameObject infoNappiCanvas; // info nappi canvas
    void Awake() // ei tuhoa tätä scriptiä kun vaihdetaan sceneä
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(infoNappi);
        DontDestroyOnLoad(infoPanel);
        DontDestroyOnLoad(infoNappiCanvas);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //kun painetaan info nappia niin info paneli tulee näkyviin ja kun painetaan uudestaan se menee pois näkyvistä

    public void InfoNappiPainettu()
    {
        if (!infoPanel.activeSelf && infoPanel != null)
        {
            infoPanel.SetActive(true);
        }
        else
        {
            infoPanel.SetActive(false);
        }
    }
}
