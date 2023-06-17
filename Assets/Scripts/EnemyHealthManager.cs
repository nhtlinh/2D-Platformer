using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyHealth;
    public GameObject deathEffect;
    public int pointsOnHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnHealth);
            Destroy(gameObject);
        }
    }

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
        //audio enemy hurt
        GetComponent<AudioSource>().Play();
    }
}
