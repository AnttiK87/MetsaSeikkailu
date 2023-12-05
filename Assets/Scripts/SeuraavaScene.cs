using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeuraavaScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in order
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
