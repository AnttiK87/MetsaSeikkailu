using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinAlkuun : MonoBehaviour
{
    public void Takaisin() // kun painetaan nappia palataan alkun�ytt��n
    {
        SceneManager.LoadScene(0);
    }
}
