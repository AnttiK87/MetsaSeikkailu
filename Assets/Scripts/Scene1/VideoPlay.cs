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
    private float delayInSeconds = 0.1f;


    //Scripti liitetty telkänpönttöön ja tällä pontto saadaan toimimaan nappina.
    //Vaatii toimiakseen objektille boxcollider komponentin.
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        videoPlayer1.Prepare();
        LoadFirstFrame();

        Invoke("ActivateObject", delayInSeconds);
        
    }

    //Avataan ui paneeli jossa video näytetään ja valmistellaan video
    void ActivateObject()
    {
        if (panel != null)
        {
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
        LoadFirstFrame2();
    }

    //metodi videon joka kutsutaan kun toinen video on lopussa
    void VideoPlaybackComplete2(VideoPlayer vp2)
    {
        panel.SetActive(false); //ui canvas kiinni
        telkka.SetActive(true); //peli hahmo näyttämölle
        Destroy(panel); //ui paneeli joutaa pois
    }

    private void LoadFirstFrame()
    {
        // Seek to the beginning of the video
        videoPlayer1.frame = 0;

        // Play a single frame to load it into the RenderTexture
        videoPlayer1.Play();
        videoPlayer1.Pause();
    }

    private void LoadFirstFrame2()
    {
        // Seek to the beginning of the video
        videoPlayer2.frame = 0;

        // Play a single frame to load it into the RenderTexture
        videoPlayer2.Play();
        videoPlayer2.Pause();
    }
}