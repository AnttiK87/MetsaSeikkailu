using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinAlkuun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //kun painetaan nappia, niin palataan 0. sceneen
    public void Takaisin()
    {
        SceneManager.LoadScene(0);
    }
}
