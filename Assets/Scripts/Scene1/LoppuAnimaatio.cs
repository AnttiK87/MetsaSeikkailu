using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoppuAnimaatio : MonoBehaviour
{
    public GameObject objektiPois;
    public GameObject objektiPaalle;
    private void OnMouseUpAsButton()
    {
        TriggeriLoppuAnim();
    }

    void TriggeriLoppuAnim()
    {
        objektiPois.SetActive(false);
        objektiPaalle.SetActive(true);
    }
}
