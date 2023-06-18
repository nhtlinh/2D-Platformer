using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        //score = 0;
        score = PlayerPrefs.GetInt("CurrentPlayerScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        // Plus Score show display
        scoreText.text = " " + score;
    }

    //Add points
    public static void AddPoints(int pointToAdd)
    {
        score += pointToAdd;
        PlayerPrefs.SetInt("CurrentPlayerScore", score);
    }

    public static void reset()
    {
        score = 0;
        PlayerPrefs.SetInt("CurrentPlayerScore", score);
    }

}
