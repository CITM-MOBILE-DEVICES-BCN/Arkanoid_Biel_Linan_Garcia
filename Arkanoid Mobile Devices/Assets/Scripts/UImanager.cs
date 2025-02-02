using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UImanager : MonoBehaviour
{

    
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text highscore;


    public void Start()
    {
        GameManager.Instance.uiManager = this;
    }


    public void UpdateLivesUI()
    {
        livesText.text = "Lifes: " + GameManager.Instance.currentLives.ToString();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }

    public void UpdareHighScore()
    {
        
        highscore.text = "Highscore: " + GameManager.Instance.highscore.ToString();

        PlayerPrefs.SetInt("Highscore", GameManager.Instance.highscore);
    }
}
