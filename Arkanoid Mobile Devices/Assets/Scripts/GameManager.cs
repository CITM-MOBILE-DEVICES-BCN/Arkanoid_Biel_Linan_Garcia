using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Data;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float checkDelay = 1.5f;
    [SerializeField] private string blockTag = "Block";
    public static int scoreValue = 0;
    public SaveandLoad saveLoad;
    public SceneController sceneController;
    public UImanager uiManager;
    public int highscore;

    public int score = 0;

    public int totalLives = 3;
    public int currentLives;
    public static GameManager Instance;
    private void Awake()
    {
        saveLoad = new SaveandLoad();
        //singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            
        }
    }

   public void continueButton()
    {
       highscore = PlayerPrefs.GetInt("Highscore");
        saveLoad.Load();

    }
    


    void Start()
    {
        currentLives = totalLives;
        StartCoroutine(CheckForBlocks());


    }

    public void LoseLife()
    {
        currentLives--;
        uiManager.UpdateLivesUI();  
        if(currentLives == 0)
        {
            GameOver();
        }
    }

    

    public void GameOver()
    {        
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void AddHitScore()
    {
        score += 50;
        uiManager.UpdateScoreUI();

        if(score > highscore)
        {
            highscore = score;
            uiManager.UpdareHighScore();

        }
    }

   

    // Updates the score display in the UI
    
    public void BlockDestroyed()
    {
        score += 100;  
        uiManager.UpdateScoreUI();
        Debug.Log("block destroy");
        if (score > highscore)
        {
            highscore = score;
            uiManager.UpdareHighScore();

        }


    }

    private IEnumerator CheckForBlocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkDelay);

            // Find all GameObjects with the specified tag
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(blockTag);

            // If no blocks are found, load the next scene
            if (blocks.Length == 0 && SceneManager.GetActiveScene().name == "Level1" || blocks.Length == 0 && SceneManager.GetActiveScene().name == "Level2")
            {
                Debug.Log("wasaa");
                sceneController.loadNextlvl();
                
            }
        }
    }
    
    
    


   

}
