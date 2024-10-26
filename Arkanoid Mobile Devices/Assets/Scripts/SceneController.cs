using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float displayDuration = 3f;
    public GameObject victoryCanvas;
    public GameObject gameCanvas;
    public GameObject pauseMenu;
    private bool isPaused = false;




    private void Start()
    {
        GameManager.Instance.sceneController = this;
    }

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

         if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    
  

    public void Resume()
    {
        pauseMenu.SetActive(false);     // Hide pause menu
        Time.timeScale = 1f;              // Resume game time
        isPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);      // Show pause menu
        Time.timeScale = 0f;              // Freeze game time
        isPaused = true;
    }
    void ShowVictoryMessage()
    {
        if (gameCanvas != null)
            gameCanvas.SetActive(false);

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true); // Show the victory canvas
            Invoke("LoadNextlvl", displayDuration); // Wait, then load the next scene
        }

    }

    

      public void menuLoad()
    {
        SceneManager.LoadScene("Menu");


    }

    public void restart()
    {
        SceneManager.LoadScene("Level1");


    }


    public void loadNewlvl()
    {
        GameManager.Instance.highscore = PlayerPrefs.GetInt("Highscore");
        SceneManager.LoadScene("Level1");

    }
    public void LoadNextlvl()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            GameManager.Instance.saveLoad.Save("Level1");
            SceneManager.LoadScene("Level1");
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameManager.Instance.saveLoad.Save("Level2");
            SceneManager.LoadScene("Level2");
        }

    }
}
