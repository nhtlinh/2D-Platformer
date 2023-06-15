using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int pointsToAdd;

    //Collision Point - Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ++score
            ScoreManager.AddPoints(pointsToAdd);
            // destroy coin
            Destroy(gameObject);
        }
    }
}
