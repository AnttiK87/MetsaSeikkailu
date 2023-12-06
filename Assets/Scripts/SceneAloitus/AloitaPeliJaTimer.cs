using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AloitaPeliJaTimer : MonoBehaviour
{
    public void StartGameAndTimer()
    {
        // Start the timer
        PelinKestoScripti timerScript = FindObjectOfType<PelinKestoScripti>();
        if (timerScript != null)
        {
            timerScript.KaynnistaAjastin();
        }
        else
        {
            // If the timer script isn't found, it could be on a non-persistent GameObject.
            // Consider alternative approaches like using static variables or Singleton pattern.
        }

        // Load Scene 1
        SceneManager.LoadScene(1); // Assuming Scene 1 is indexed as 1
    }
}
