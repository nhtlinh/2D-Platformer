using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public string levelSelect;
    //Player Prefs
    public int playerLives;
    public int playerHealth;
 
    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);
        PlayerPrefs.SetInt("MaxPlayerHealth", playerHealth);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);
        PlayerPrefs.SetInt("MaxPlayerHealth", playerHealth);
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
