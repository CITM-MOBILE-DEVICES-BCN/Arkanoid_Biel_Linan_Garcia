using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float displayDuration = 3f;
    public GameObject victoryCanvas;
    public GameObject gameCanvas;
    
    void Update()
    {
        // Check if we're currently in Level 2
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            // Find all objects tagged as "Block"
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

            // If there are no blocks left, load Level 1
            if (blocks.Length == 0)
            {
               ShowVictoryMessage();

            }
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

            if (blocks.Length == 0)
            {
                ShowVictoryMessage();
            }
        }
    }


    void ShowVictoryMessage()
    {
        if (gameCanvas != null)
            gameCanvas.SetActive(false);

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true); // Show the victory canvas
            Invoke("LoadNextScene", displayDuration); // Wait, then load the next scene
        }

    }

      public void menuLoad()
    {
        SceneManager.LoadScene("Menu");


    }


    public void loadNextlvl()
    {
        if (SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Level1");
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }

    }
}
