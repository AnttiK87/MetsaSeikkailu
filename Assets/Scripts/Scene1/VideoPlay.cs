using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;
    public GameObject panel;
    public GameObject button1;
    public GameObject button2;
    public GameObject rawImageVideo1;
    public GameObject rawImageVideo2;
    public GameObject telkka;
    private void OnMouseUpAsButton()
    {
        //Debug.Log("nappia painettu");
        ActivateObject();
    }


    // Start is called before the first frame update
    void ActivateObject()
    {
        if (panel != null)
        {
            videoPlayer1.Prepare();
            panel.SetActive(true);
        }
    }

    public void PlayVideo1()
    {
        videoPlayer1.Play();
        videoPlayer1.loopPointReached += VideoPlaybackComplete;
    }

    public void PlayVideo2()
    {
        rawImageVideo1.SetActive(false);
        rawImageVideo2.SetActive(true);
        videoPlayer2.Play();
        videoPlayer2.loopPointReached += VideoPlaybackComplete2;
    }
    void VideoPlaybackComplete(VideoPlayer vp)
    {
        button1.SetActive(false);
        button2.SetActive(true);
        videoPlayer2.Prepare();
    }

    void VideoPlaybackComplete2(VideoPlayer vp2)
    {
        panel.SetActive(false);
        telkka.SetActive(true);
    }
}