using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public static int playerHealth;

    TextMeshProUGUI healthText;

    LevelManager levelManager;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        levelManager = FindObjectOfType<LevelManager>();

        playerHealth = maxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
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
    }

    //Full Health
    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
