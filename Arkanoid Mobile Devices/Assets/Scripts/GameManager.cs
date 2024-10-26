using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Data;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float checkDelay = 0.5f;
    [SerializeField] private string blockTag = "Block";
    public static int scoreValue = 0;
    public TextMeshProUGUI scoreText;

    
    private int score = 0;

    public int totalLives = 3;
    public int currentLives;
    public TextMeshProUGUI livesText;
    public static GameManager Instance {  get; private set; }
    private void Awake()
    {
        //singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    
    void Start()
    {
        currentLives = totalLives;
        UpdateScoreUI();
        UpdateLivesUI();
        StartCoroutine(CheckForBlocks());


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
                SceneManager.LoadScene("Level1");
            }
        }

    }

        public void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();

        if(currentLives == 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }

    public void GameOver()
    {        
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void AddHitScore()
    {
        score += 50;
        UpdateScoreUI();
    }

   

    // Updates the score display in the UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
    public void BlockDestroyed()
    {
        score += 100;  
        UpdateScoreUI();
        Debug.Log("block destroy");
      
    }

    private IEnumerator CheckForBlocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkDelay);

            // Find all GameObjects with the specified tag
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(blockTag);

            // If no blocks are found, load the next scene
            if (blocks.Length == 0)
            {
                LoadNextLevel();
                
            }
        }
    }
    
    
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }

}
