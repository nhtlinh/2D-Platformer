using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //public int maxPlayerHealth;
    public static int playerHealth;

    TextMeshProUGUI healthText;

    LevelManager levelManager;

    public bool isDead;

    //LifeManager
    LifeManager lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        levelManager = FindObjectOfType<LevelManager>();

        //playerHealth = maxPlayerHealth;
        playerHealth = PlayerPrefs.GetInt("CurrentPlayerHealth");

        isDead = false;

        lifeSystem = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            lifeSystem.TakeLife();
            levelManager.RespawnPlayer();
            isDead = true;
        }
        // Plus Score show display
        healthText.text = " " + playerHealth;
    }

    //Hurt Player
    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);
    }

    //Full Health
    public void FullHealth()
    {
        playerHealth = PlayerPrefs.GetInt("MaxPlayerHealth");
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);
    }
}
