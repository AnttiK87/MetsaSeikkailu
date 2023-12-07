using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    //Luokka tai scripti alussa olevien videoiden näyttämiselle

    //muuttujat
    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;
    public GameObject panel;
    public GameObject button1;
    public GameObject button2;
    public GameObject rawImageVideo1;
    public GameObject rawImageVideo2;
    public GameObject telkka;

    //Scripti liitetty telkänpönttöön ja tällä pontto saadaan toimimaan nappina.
    //Vaatii toimiakseen objektille boxcollider komponentin.
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    //Avataan ui paneeli jossa video näytetään ja valmistellaan video
    void ActivateObject()
    {
        if (panel != null)
        {
            videoPlayer1.Prepare();
            panel.SetActive(true);
        }
    }

    //Liitetään uissa olevaan nappiin ja tällä video lähtee käyntiin
    public void PlayVideo1()
    {
        videoPlayer1.Play();
        videoPlayer1.loopPointReached += VideoPlaybackComplete; //katsotaan milloin video on näytetty loppuun ja kutsutaan metodia
    }

    //Liitetään uissa olevaan nappiin ja tällä seuraava video lähtee käyntiin
    public void PlayVideo2()
    {
        rawImageVideo1.SetActive(false);
        rawImageVideo2.SetActive(true);
        videoPlayer2.Play();
        videoPlayer2.loopPointReached += VideoPlaybackComplete2;
    }

    //metodi videon joka kutsutaan kun ensimmäinen video on lopussa
    void VideoPlaybackComplete(VideoPlayer vp)
    {
        button1.SetActive(false);
        button2.SetActive(true);
        videoPlayer2.Prepare();
    }

    //metodi videon joka kutsutaan kun toinen video on lopussa
    void VideoPlaybackComplete2(VideoPlayer vp2)
    {
        panel.SetActive(false); //ui canvas kiinni
        telkka.SetActive(true); //peli hahmo näyttämölle
        Destroy(panel); //ui paneeli joutaa pois
    }
}