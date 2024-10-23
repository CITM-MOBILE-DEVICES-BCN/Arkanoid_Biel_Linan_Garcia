using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int blockCount;
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
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
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
