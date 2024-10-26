using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveandLoad
{
    

   public void Save(string sceneindex)
    {        
        PlayerPrefs.SetInt("score", GameManager.Instance.score);
        PlayerPrefs.SetInt("lifes", GameManager.Instance.currentLives);
        PlayerPrefs.SetString("scene", sceneindex);

        PlayerPrefs.Save();
    }


    public void Load()
    {

        GameManager.Instance.score = PlayerPrefs.GetInt("score");
        GameManager.Instance.currentLives = PlayerPrefs.GetInt("lifes");
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
    }
}
