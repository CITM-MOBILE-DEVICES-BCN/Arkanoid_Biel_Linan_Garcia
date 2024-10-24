using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Data;
public class GameManager : MonoBehaviour
{
    public static int scoreValue = 0;
    public TextMeshProUGUI scoreText;

    public int blockCount;
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
        UpdateLivesUI();
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();

        if(currentLives <= 1)
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
    }

    public void AddHitScore()
    {
        score += 50;
        UpdateScoreUI();
    }

    public void AddDestroyScore()
    {
        score += 100;  // Adds 100 points when destroying a block
        UpdateScoreUI();
    }

    // Updates the score display in the UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    /*public void BlockDestroyed()
    {
        blockCount--;
        if(blockCount <= 0)
        {
            LoadNextLevel();
        }
    }*/

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
