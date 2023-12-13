using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    //Luokka tai scripti alussa olevien videoiden n�ytt�miselle

    //muuttujat
    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;
    public GameObject panel;
    public GameObject button1;
    public GameObject button2;
    public GameObject rawImageVideo1;
    public GameObject rawImageVideo2;
    public GameObject telkka;

    //Scripti liitetty telk�np�ntt��n ja t�ll� pontto saadaan toimimaan nappina.
    //Vaatii toimiakseen objektille boxcollider komponentin.
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }

    //Avataan ui paneeli jossa video n�ytet��n ja valmistellaan video
    void ActivateObject()
    {
        if (panel != null)
        {
            
            videoPlayer1.Prepare();
            LoadFirstFrame();
            panel.SetActive(true);
        }
    }

    //Liitet��n uissa olevaan nappiin ja t�ll� video l�htee k�yntiin
    public void PlayVideo1()
    {
        videoPlayer1.Play();
        videoPlayer1.loopPointReached += VideoPlaybackComplete; //katsotaan milloin video on n�ytetty loppuun ja kutsutaan metodia
    }

    //Liitet��n uissa olevaan nappiin ja t�ll� seuraava video l�htee k�yntiin
    public void PlayVideo2()
    {
        rawImageVideo1.SetActive(false);
        rawImageVideo2.SetActive(true);
        videoPlayer2.Play();
        videoPlayer2.loopPointReached += VideoPlaybackComplete2;
    }

    //metodi videon joka kutsutaan kun ensimm�inen video on lopussa
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
        telkka.SetActive(true); //peli hahmo n�ytt�m�lle
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
}