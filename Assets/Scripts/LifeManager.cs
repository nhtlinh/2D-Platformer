using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    //public int startingLives;
    int m_lifeCounter;
    Text m_text;
    //GameOver
    public GameObject gameOverScreen;
    public PlayerController player;

    public string mainMenu;
    public float waitAfterGameOver;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
        m_lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_lifeCounter <= 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }

        m_text.text = "x " + m_lifeCounter;

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if (waitAfterGameOver < 0)
        {
            SceneManager.LoadScene(mainMenu);   
        }
    }

    public void GiveLife()
    {
        m_lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", m_lifeCounter);
    }

    public void TakeLife()
    {
        m_lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", m_lifeCounter);
    }

}
